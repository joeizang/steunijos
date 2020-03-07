using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IHostEnvironment _env;

        public HomeController(SteunijosContext db, IHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var path = Path.Combine(_env.ContentRootPath, "Uploads", "Journals");
            var thumb = new IconThumbnail();
            var dir = new DirectoryInfo(path);
            //Get Journals and how them on the homepage.
            var journals = await _db.Journals.AsNoTracking()
                              .Select(j => new JournalReadModel
                              {
                                  CopyrightYear = j.CopyrightYear,
                                  IssnNo = j.IssnNo,
                                  VolumeName = j.VolumeName
                              }).ToListAsync().ConfigureAwait(false);

            var pdfFiles = dir.EnumerateFiles()
                           .Where(x => x.Extension.Equals("pdf"))
                           .ToList();
            journals.ForEach(j =>
            {
                pdfFiles.ForEach(p =>
                {
                    if (j.ActualFileName == p.Name)
                    {
                        //finish this off.d
                    }
                })
            })

            return View(journals);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
