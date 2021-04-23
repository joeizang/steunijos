using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Steunijos.Domain.DomainModels;
using Steunijos.WebUI.Data;
using Steunijos.WebUI.ViewModels.Paper;

namespace Steunijos.WebUI.Controllers
{
    [Authorize]
    public class PapersController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly SteunijosContext _db;
        //private readonly IGoogleDriveService _gds;

        public PapersController(IWebHostEnvironment env,
            SteunijosContext db)
        {
            _env = env;
            _db = db;
            //_gds = gds;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _db.Papers.AsNoTracking()
                .Select(p => new PaperIndexViewModel
                {
                    PaperId = p.Id,
                    PaperTitle = p.Title,
                    SubmissionDate = p.CreatedAt
                })
                .ToListAsync()
                .ConfigureAwait(false);

            return View(result);
        }

        // GET: Paper/Details/5
        public async Task<ActionResult> Details(int id, CancellationToken token)
        {
            var paper = await _db.Papers.AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new PaperDetailsViewModel
                {
                    JournalId = p.JournalId,
                    PaperId = p.Id,
                    PaperOriginalName = p.PaperOriginalName,
                    SubjectArea = p.SavedPath,
                    ThumbnailPath = p.ThumbnailPath
                }).SingleOrDefaultAsync(token).ConfigureAwait(false);

            return View(paper);
        }

        public ActionResult SubmitPaper()
        {
            var submitPaper = new SubmitPaper
            {
                SubjectArea = SubjectAreaEnum.SelectASubjectArea
            };

            return View(submitPaper);
        }

        // POST: Paper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitPaper(SubmitPaper submitPaper)
        {

            try
            {
                var dir = $"{_env.WebRootPath}";
                var uploadPath = Path.Combine(dir, "Uploads");
                var modifiedFileName = $"{DateTimeOffset.UtcNow.LocalDateTime.Ticks}-{submitPaper.File.FileName}";
                var combinedPath = Path.Combine(uploadPath, modifiedFileName);

                using (var fstream = new FileStream(combinedPath, FileMode.Create, FileAccess.Write))
                {
                    await submitPaper.File.CopyToAsync(fstream);
                    var fileInfo = new FileInfo(combinedPath);
                    //rename the file on disk to a new name
                    var copyPath = Path.Combine(uploadPath, $"{DateTimeOffset.Now.Ticks}-{Guid.NewGuid()}{fileInfo.Extension}");
                    fileInfo.CopyTo(copyPath);
                    //var enumName = EnumValueToStringConverter.ConvertToString(submitPaper.SubjectArea);
                   // var enumName = submitPaper.SubjectArea.ConvertToString();
                    //save paper to db after taking all the info from submitPaper
                    var paper = new Paper
                    {
                        Title = submitPaper.Title,
                        ActualPath = $"{combinedPath}",
                        SavedPath = copyPath,
                        PaperOriginalName = submitPaper.File.FileName,
                        CreatedAt = submitPaper.DateUploaded,
                    };

                    _db.Papers.Add(paper);
                    var pId = await _db.SaveChangesAsync().ConfigureAwait(false);
                }

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }

            ViewBag.Message = "Upload Successful!";
            return RedirectToRoute(new { controller = "Papers", action = "Index" });
        }

        // GET: Paper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paper/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
