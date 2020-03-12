using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steunijos.Web.Data;
using Steunijos.Web.Models;
using Steunijos.Web.ViewModels.Journal;
using ThumbnailsGenie;

namespace Steunijos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SteunijosContext _db;
        private readonly IWebHostEnvironment _env;

        public HomeController(SteunijosContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var uploadPath = Path.Combine(_env.WebRootPath, "Uploads");
            var journalPath = Path.Combine(uploadPath, "Journals");
            var thumb = new IconThumbnail();
            var dir = new DirectoryInfo(journalPath);
            //Get Journals and how them on the homepage.
            var journals = await _db.Journals.AsNoTracking()
                              .Select(j => new JournalReadModel
                              {
                                  CopyrightYear = j.CopyrightYear,
                                  IssnNo = j.IssnNo,
                                  VolumeName = j.VolumeName
                              }).ToListAsync().ConfigureAwait(false);

            List<FileInfo> pdfFiles;

            if (!dir.Exists)
            {
                dir.Create();
            }

            pdfFiles = dir.EnumerateFiles()
                           .Where(x => x.Extension.Equals("pdf"))
                           .ToList();

            journals.ForEach(j =>
            {
                pdfFiles.ForEach(p =>
                {
                    if (j.ActualFileName.Contains(p.Name) && p.Extension.Contains("pdf"))
                    {
                        //finish this off.d
                        var thum = thumb.GetThumbnailForExtension(p.Extension, Thumbnails.Size.Px48);
                    }
                });
            });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
