﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IHostEnvironment _env;

        [TempData]
        public string Message { get; set; }

        public JournalsController(SteunijosContext db, IHostEnvironment env)
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
        public ActionResult Details(int id)
        {
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
                var dir = $"{_env.ContentRootPath}";
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

        // GET: Journal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Journal/Edit/5
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

        // GET: Journal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Journal/Delete/5
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