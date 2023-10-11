﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PictureController : Controller
    {
        // GET: PictureController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PictureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PictureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PictureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PictureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PictureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PictureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PictureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
