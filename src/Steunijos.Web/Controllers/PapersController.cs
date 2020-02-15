using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Steunijos.Web.Data;
using Steunijos.Web.ViewModels;
using Steunijos.Web.ViewModels.Paper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Steunijos.Web.Controllers
{
    public class PapersController : Controller
    {
        private readonly IHostEnvironment _env;
        private readonly SteunijosContext _db;

        public PapersController(IHostEnvironment env, SteunijosContext db)
        {
            _env = env;
            _db = db;
        }


        // GET: Paper
        public async Task<ActionResult> Index(PaperInputModel model)
        {
            var deferredPapers = _db.Papers.AsNoTracking();
            var filteredBySubjectArea = deferredPapers.Include(x => x.SubjectArea)
                                        .OrderBy(p => p.SubjectArea.SubjectAreaName)
                                        .ThenByDescending(p => p.SubjectArea.SubjectAreaName);
            var filteredByDateSubmitted = deferredPapers.OrderBy(p => p.CreatedAt);
            var filteredByAuthorName = deferredPapers.Include(x => x.Authors)
                                        .OrderBy(p => p.Authors.Select(x => x.PaperAuthor.FirstName))
                                        .ThenBy(p => p.Authors.Select(x => x.PaperAuthor.LastName));
            if(model.SortCriterion == SortBy.Author_Name.ToString())
            {
                // Add pagination later for when the list of papers gets long.
                var result = await filteredByAuthorName.ToListAsync();
                return View(result);
            }
            if(model.SortCriterion == SortBy.Date_Submitted.ToString())
            {
                var result = await filteredByDateSubmitted.ToListAsync();
                return View(result);
            }
            if (model.SortCriterion == SortBy.Subject_Area.ToString())
            {
                var result = await filteredBySubjectArea.ToListAsync();
                return View(result);
            }

            return View(await deferredPapers.ToListAsync());
        }

        // GET: Paper/Details/5
        public ActionResult Details(string id)
        {
            
            return View();
        }

        public ActionResult SubmitPaper()
        {
            ViewBag.EnvPath = "..\\..\\"+_env;
            return View("SubmitPaper");
        }

        // GET: Paper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitPaper(SubmitPaper submitPaper)
        {
            try
            {
                var dir = $"{_env.ContentRootPath}";
                ViewBag.EnvPath = dir;
                var combinedPath = Path.Combine(dir, submitPaper.File.FileName);

                using(var fstream = new FileStream(combinedPath, 
                    FileMode.Create, FileAccess.Write))
                {
                    await submitPaper.File.CopyToAsync(fstream);
                }

            }
            catch
            {
                return View();
            }
                return RedirectToAction(nameof(Index));
        }

        // GET: Paper/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paper/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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