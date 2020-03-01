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
using Steunijos.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using System.Threading;
using Google.Apis.Services;
using Steunijos.Web.SteunijosServices;

namespace Steunijos.Web.Controllers
{
    public class PapersController : Controller
    {
        private readonly IHostEnvironment _env;
        private readonly SteunijosContext _db;
        private readonly IGoogleDriveService _gds;

        public PapersController(IHostEnvironment env,
            SteunijosContext db,
            IConfiguration config,
            IGoogleDriveService gds)
        {
            _env = env;
            _db = db;
            _gds = gds;
        }

        // GET: Paper/Details/5
        public ActionResult Details(string id)
        {

            return View();
        }

        public ActionResult SubmitPaper()
        {
            var submitPaper = new SubmitPaper();
            submitPaper.SubjectArea = new List<SelectListItem>{
                new SelectListItem{ Text="Select a Subject Area", Value=""},
                new SelectListItem{ Text="Biology Education", Value="Biology Education"},
                new SelectListItem{ Text="Building Education", Value="Building Education"},
                new SelectListItem{ Text="Chemistry Education", Value="Chemistry Education"},
                new SelectListItem{ Text="Computer Science", Value="Computer Science"},
                new SelectListItem{ Text="Electrical Technology", Value="Electrical Technology"},
                new SelectListItem{ Text="Geography Education", Value="Geography Education"},
                new SelectListItem{ Text="Integrated Science Education", Value="Integrated Science Education"},
                new SelectListItem{ Text="Mathematics Education", Value="Mathematics Education"},
                new SelectListItem{ Text="Welding Technology Education", Value="Welding Technology Education"},

            };
            return View(submitPaper);
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

                using (var fstream = new FileStream(combinedPath,
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