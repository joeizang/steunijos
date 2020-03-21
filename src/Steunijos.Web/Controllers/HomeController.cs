using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Steunijos.Web.Data;
using Steunijos.Web.ViewModels.Journal;

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
            var context = HttpContext.User.Identity.IsAuthenticated;
            var uploadPath = Path.Combine(_env.WebRootPath, "Uploads");
            var journalPath = Path.Combine(uploadPath, "Journals");
            var dir = new DirectoryInfo(journalPath);
            //Get Journals and how them on the homepage.
            var journals = await _db.Journals.AsNoTracking()
                              .Select(j => new JournalReadModel
                              {
                                  CopyrightYear = j.CopyrightYear,
                                  IssnNo = j.IssnNo,
                                  VolumeName = j.VolumeName,
                                  ActualFileName = j.ActualPath,
                                  CreatedAt = j.CreatedAt
                              }).ToListAsync().ConfigureAwait(false);
            
            
            return View(journals);
        }
        
        [HttpGet]
        public async Task<ActionResult> DownloadJournals([FromQuery] JournalDownloadModel model)
        {
            var journal = await _db.Journals.AsNoTracking()
                .SingleOrDefaultAsync(x => x.VolumeName.Equals(model.VolumeName) || 
                                           x.IssnNo.Equals(model.IssnNumber))
                .ConfigureAwait(false);

            var fileName = Path.GetFileName(journal.ActualPath);
            var uploadFolder = Path.Combine(_env.WebRootPath, "Uploads");
            var fileDownload = Path.Combine(uploadFolder, fileName);
            //var file = new FileInfo(fileDownload);
            // if (!file.Exists)
            // {
            //     return Json(
            //         new
            //         {
            //             ErrorMessage = "The file you are trying to download doesn't exist!",
            //             ErrorCode = 404
            //         });
            // }

            try
            {
                var memoryStream = new MemoryStream();
                Console.WriteLine($"Memory Stream created at { DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                using (var stream = new FileStream(journal.ActualPath, FileMode.Open))
                {
                    Console.WriteLine($"File Stream created at { DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                    await stream.CopyToAsync(memoryStream);
                    Console.WriteLine($"File Stream copied to Memory Stream at { DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
                }
                memoryStream.Position = 0;
                Console.WriteLine($"Memory Stream position set at { DateTimeOffset.UtcNow.LocalDateTime.ToString()}");
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

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
