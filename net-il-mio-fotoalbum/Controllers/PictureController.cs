using Microsoft.AspNetCore.Http;
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
        private IRepository<Picture, PictureFormModel> _repositoryPicture;
        private IRepository<Category, CategoryFormModel> _repositoryCategory;


        public PictureController(IRepository<Picture, PictureFormModel> repositoryPicture, IRepository<Category, CategoryFormModel> repositoryCategory)
        {
            _repositoryPicture = repositoryPicture;
            _repositoryCategory = repositoryCategory;
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
            List<SelectListItem> allCategoriesSelectList = new List<SelectListItem>();
            List<Category> databaseAllCategories = _repositoryCategory.GetAll();

            foreach (Category Category in databaseAllCategories)
            {
                allCategoriesSelectList.Add(
                    new SelectListItem
                    {
                        Text = Category.Name,
                        Value = Category.Id.ToString()
                    });
            }

            PictureFormModel formModel = new PictureFormModel
            {
                Picture = new Picture(),
                Categories = allCategoriesSelectList
            };


            return View("Create", formModel);



        }

        // POST: PictureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PictureFormModel formModel)
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
