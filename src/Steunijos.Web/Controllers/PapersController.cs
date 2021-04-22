using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Steunijos.Web.Data;
using Steunijos.Web.ViewModels.Paper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Steunijos.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Steunijos.Web.SteunijosServices;

namespace Steunijos.Web.Controllers
{
    [Authorize]
    public class PapersController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly SteunijosContext _db;
        //private readonly IGoogleDriveService _gds;

        public PapersController(IWebHostEnvironment env,
            SteunijosContext db,
            IConfiguration config,
            IGoogleDriveService gds)
        {
            _env = env;
            _db = db;
            //_gds = gds;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _db.Papers.AsNoTracking()
                .Include(p => p.SubjectArea)
                .Select(p => new PaperIndexViewModel
                {
                    AuthorName = p.AuthorName,
                    PaperId = p.PaperId,
                    PaperTitle = p.Title,
                    SubjectArea = p.SubjectArea.SubjectAreaName,
                    SubmissionDate = p.CreatedAt
                })
                .ToListAsync()
                .ConfigureAwait(false);

            return View(result);
        }

        // GET: Paper/Details/5
        public async Task<ActionResult> Details(string id, CancellationToken token)
        {
            var paper = await _db.Papers.AsNoTracking()
                .Where(p => p.PaperId == id)
                .Select(p => new PaperDetailsViewModel
                {
                    AuthorName = p.AuthorName,
                    JournalId = p.JournalId,
                    PaperId = p.PaperId,
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
                SubjectArea = SubjectAreaEnum.Select_a_Subject_Area
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
                    var enumName = submitPaper.SubjectArea.ConvertToString();
                    //save paper to db after taking all the info from submitPaper
                    var paper = new Paper
                    {
                        PaperId = Guid.NewGuid().ToString(),
                        Title = submitPaper.Title,
                        ActualPath = $"{combinedPath}",
                        SavedPath = copyPath,
                        SubjectArea = new SubjectArea
                        {
                            SubjectAreaId = Guid.NewGuid().ToString(),
                            SubjectAreaName = enumName
                        },
                        PaperOriginalName = submitPaper.File.FileName,
                        CreatedAt = submitPaper.DateUploaded,
                        AuthorName = submitPaper.Author
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