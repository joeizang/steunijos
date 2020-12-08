using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Steunijos.Web.Data;
using Steunijos.Web.Models;
using Steunijos.Web.ViewModels.Journal;

namespace Steunijos.Web.Controllers
{
    public class JournalsController : Controller
    {
        private readonly SteunijosContext _db;
        private readonly IWebHostEnvironment _env;
        private List<ShowJournalViewModel> ShowJournalVM { get; set; }

        [TempData]
        public string Message { get; set; }

        public JournalsController(SteunijosContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
            ShowJournalVM = new List<ShowJournalViewModel>();
        }
        // GET: Journal
        public async Task<ActionResult> Index()
        {
            var result = await _db.Journals.AsNoTracking()
                .Select(j => new JournalReadModel
                {
                    IssnNo = j.IssnNo,
                    CopyrightYear = j.CopyrightYear,
                    VolumeName = j.VolumeName
                }).ToListAsync()
                .ConfigureAwait(false);

            return View(result);
        }

        // GET: Journal/Details/5
        //explore the option of using google docs viewer to show a document.
        //look into exploring the url to the static pdf file to be viewed
        //so that the viewer can display the file.
        public async Task<ActionResult> Details(string issn)
        {
            var journal = await _db.Journals.AsNoTracking()
                .Where(j => j.IssnNo.Equals(issn))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            var mstream = new MemoryStream();
            var journalPath = "";
            using (var stream = new FileStream(journalPath, FileMode.Open))
            {
                if (stream.Name.Contains(journal.ActualPath))
                {
                    await stream.CopyToAsync(mstream).ConfigureAwait(false);
                }
            }
            /*
             * The plan would be to create the url or uri and pass it over to the view and
             * the hand the composed uri to google doc viewer and have it open the file.
             */
            
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ShowJournals()
        {
            ShowJournalVM = await _db.Journals.AsNoTracking()
                .Select(j => new ShowJournalViewModel
                {
                    JournalYear = j.CopyrightYear,
                    ActualFileName = Path.GetFileName(j.ActualPath),
                    JournalVolumeName = j.VolumeName,
                    JournalISSN = j.IssnNo
                }).ToListAsync().ConfigureAwait(false);
            return PartialView("_ShowJournals", ShowJournalVM);
        }

        // GET: Journal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JournalInputModel inputModel, CancellationToken token)
        {
            try
            {
                var dir = $"{_env.WebRootPath}";
                var uploadPath = Path.Combine(dir, "Uploads");
                var journalPath = Path.Combine(uploadPath, "Journals");
                var combinedPath = Path.Combine(journalPath, $"{inputModel.File.FileName}");

                using (var fstream = new FileStream(combinedPath, FileMode.Create, FileAccess.Write))
                {
                    var fileInfo = new FileInfo(combinedPath);

                    //TODO: check that the file size isn't too big, figure out way to not accept executables or other file types.
                    //TODO: make sure that only authorized users can upload journals.

                    await inputModel.File.CopyToAsync(fstream,token);

                    //rename the file on disk to a new name

                    var copyPath = Path.Combine(journalPath,
                        $"{DateTimeOffset.Now.Ticks}-{Guid.NewGuid()}{fileInfo.Extension}");
                    fileInfo.CopyTo(copyPath);

                    //save paper to db after taking all the info from submitPaper
                    var journal = new Journal
                    {
                        IssnNo = inputModel.JournalIssn,
                        ActualPath = $"{combinedPath}",
                        SavedPath = $"{Url.Content("~/AppUploads/Journals/")}{fileInfo.Name}",
                        CopyrightYear = inputModel.CopyrightYear,
                        CreatedAt = inputModel.UploadDate,
                        VolumeName = inputModel.JournalVolume
                    };

                    _db.Journals.Add(journal);
                    var pId = await _db.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Message = e.Message;
                TempData["message"] = Message;
                return View();
            }

            Message = "Journal upload successful!"; //This should be a tempdata artifact that will be displayed on success.

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}