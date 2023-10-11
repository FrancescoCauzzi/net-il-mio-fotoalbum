﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.DatabaseModels;

using Microsoft.EntityFrameworkCore;


namespace net_il_mio_fotoalbum.Controllers
{
    public class PictureController : Controller
    {
        private readonly IRepository<Picture, PictureFormModel> _repositoryPicture;

        public PictureController(IRepository<Picture, PictureFormModel> repositoryPicture)
        {
            _repositoryPicture = repositoryPicture;
        }
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
            var model = new PictureFormModel
            {
                Categories = new List<SelectListItem> { /*... populate your categories here ...*/ }
            };
            return View("Create");
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
                return View("Create");
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
        /*
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
        */
        
    }
}
