using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [TempData]
        public string Message { get; set; }

        public JournalsController(SteunijosContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
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

        // GET: Journal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JournalInputModel inputModel)
        {
            try
            {
                var dir = $"{_env.WebRootPath}";
                var uploadPath = Path.Combine(dir, "Uploads");
                var journalPath = Path.Combine(uploadPath, "Journals");
                var combinedPath = Path.Combine(journalPath, $"{DateTimeOffset.UtcNow.LocalDateTime.Ticks}{inputModel.File.FileName}");

                using (var fstream = new FileStream(combinedPath, FileMode.Create, FileAccess.Write))
                {
                    var fileInfo = new FileInfo(combinedPath);

                    await inputModel.File.CopyToAsync(fstream);

                    //rename the file on disk to a new name

                    var copyPath = Path.Combine(journalPath,
                        $"{DateTimeOffset.Now.Ticks.ToString()}-{Guid.NewGuid().ToString()}{fileInfo.Extension}");
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
                    var pId = await _db.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Message = e.Message;
                return View();
            }

            Message = "Journal upload successful!";

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}