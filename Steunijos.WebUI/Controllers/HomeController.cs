using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steunijos.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Steunijos.WebUI.Data;
using Steunijos.WebUI.ViewModels.Journal;

namespace Steunijos.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SteunijosContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SteunijosContext db, IWebHostEnvironment env, ILogger<HomeController> logger)
        {
            _db = db;
            _env = env;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var context = HttpContext.User.Identity?.IsAuthenticated;
            var uploadPath = Path.Combine(_env.WebRootPath, "Uploads");
            var journalPath = Path.Combine(uploadPath, "Journals");
            var dir = new DirectoryInfo(journalPath);
            //Get Journals and how them on the homepage.
            var journals = await _db.Journals.AsNoTracking()
                .Select(j => new JournalReadModel
                {
                    JournalId = j.Id,
                    CopyrightYear = j.CopyrightYear.Value,
                    IssnNo = j.IssnNo,
                    VolumeName = j.VolumeName,
                    ActualFileName = j.ActualPath,
                    CreatedAt = j.CreatedAt
                }).ToListAsync().ConfigureAwait(false);


            return View(journals);
        }

        [HttpGet]
        public async Task<ActionResult> DownloadJournals([FromQuery] JournalDownloadModel model,
            CancellationToken token)
        {
            try
            {
                var journal = await _db.Journals.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.VolumeName.Equals(model.VolumeName) &&
                                               x.Id.Equals(model.JournalId), token).ConfigureAwait(false);

                _logger.LogInformation($"Found target Journal {journal.VolumeName}");

                var fileName = Path.GetFileName(journal.ActualPath);
                var uploadFolder = Path.Combine(_env.WebRootPath, "Uploads");
                var journalPath = Path.Combine(uploadFolder, "Journals");
                var fileDownload = Path.Combine(journalPath, fileName);

                _logger.LogInformation("Path to file for download is ready!");
                var memoryStream = new MemoryStream();
                Console.WriteLine($"Memory Stream created at {DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                using (var stream = new FileStream(journal.ActualPath, FileMode.Open))
                {
                    Console.WriteLine($"File Stream created at {DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                    await stream.CopyToAsync(memoryStream);
                    Console.WriteLine(
                        $"File Stream copied to Memory Stream at {DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                }

                memoryStream.Position = 0;
                Console.WriteLine($"Memory Stream position set at {DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                return File(memoryStream, GetContentType(fileDownload), fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/pdf";
            }

            return contentType;
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
