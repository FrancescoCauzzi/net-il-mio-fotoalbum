using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models.DatabaseModels;
using net_il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Authorization;

namespace net_il_mio_fotoalbum.Controllers
{
    [Authorize(Roles = "ADMIN,USER")]
    public class CategoryController : Controller
    {
        
        private IRepository<Category, CategoryFormModel> _repositoryCategory;


        public CategoryController(IRepository<Category, CategoryFormModel> repositoryCategory)
        {            
            _repositoryCategory = repositoryCategory;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            List<Category> categories = _repositoryCategory.GetAll();

            return View("Index", categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CategoryController/Create
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormModel formModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", formModel);
                }
                bool result = _repositoryCategory.AddEntity(formModel);
                if (!result)
                {
                    string message = "There was a problem in adding the category to the database";
                    var errorModel = new ErrorViewModel
                    {
                        //ErrorMessage = $"An error occurred: {ex.Message}",
                        ErrorMessage = message,
                        RequestId = HttpContext.TraceIdentifier
                    };
                    return View("Error", errorModel);
                }
                return RedirectToAction("Index");   
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
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

        // GET: CategoryController/Delete/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int id)
        {

            try
            {
                bool result = _repositoryCategory.DeleteEntity(id);
                if (!result)
                {
                    string message = "There was a problem in deleting the category";
                    var errorModel = new ErrorViewModel
                    {
                        ErrorMessage = message,
                        RequestId = HttpContext.TraceIdentifier
                    };
                    return View("Error", errorModel);
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                string innerException = "";
                if (ex.InnerException != null)
                {
                    innerException = ex.InnerException.ToString();
                }
                var errorModel = new ErrorViewModel
                {
                    ErrorMessage = $"{ex.Message}: {innerException}",
                    RequestId = HttpContext.TraceIdentifier
                };
                return View("Error", errorModel);

            }
        }

        // POST: CategoryController/Delete/5
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
