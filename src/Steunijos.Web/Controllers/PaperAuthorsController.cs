using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steunijos.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Steunijos.Web.Controllers
{
    public class PaperAuthorsController : Controller
    {
        private readonly SteunijosContext _db;

        public PaperAuthorsController(SteunijosContext db)
        {
            _db = db;
        }
        // GET: PaperAuthors
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaperAuthors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaperAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaperAuthors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaperAuthors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaperAuthors/Edit/5
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

        // GET: PaperAuthors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaperAuthors/Delete/5
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