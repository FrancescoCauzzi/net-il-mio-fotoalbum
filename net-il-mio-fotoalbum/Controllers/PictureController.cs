﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.DatabaseModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace net_il_mio_fotoalbum.Controllers
{
    [Authorize(Roles = "ADMIN,USER")]
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
            try
            {
                List<Picture> pictures = _repositoryPicture.GetAll();
                return View("Index",pictures);

            }
            catch (Exception ex)
            {
                var response = new
                {
                    success = false,
                    message = ex.Message
                };
                return BadRequest(response);
            }
        }

        // GET: PictureController/Details/5
        public ActionResult Details(int id)
        {
            Picture? foundedPicture = _repositoryPicture.GetEntityById(id);

            if(foundedPicture == null)
            {
                var errorModel = new ErrorViewModel
                {
                    ErrorMessage = $"The item with id:{id} was not found!",
                    RequestId = HttpContext.TraceIdentifier
                };
                return View("Error", errorModel);
            }

            return View("Details",foundedPicture);

        }
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PictureFormModel formModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    // now I initialize a new empty list
                    List<SelectListItem> allCategoriesSelectList = new List<SelectListItem>();
                    // and I fill it with all the categorys because I want to show them in the form again if the form is not filled well so the user can input them again

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

                    formModel.Categories = allCategoriesSelectList;

                    return View("Create", formModel);
                }
                bool result = _repositoryPicture.AddEntity(formModel);
                if (!result)
                {
                    string message = "There was a problem in adding the picture to the database";
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

        // GET: PictureController/Edit/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Update(int id)
        {
            try
            {
                Picture? pictureToEdit = _repositoryPicture.GetEntityById(id);
                if(pictureToEdit == null)
                {
                    string message = "The picture you are trying to modify has not been found";
                    var errorModel = new ErrorViewModel
                    {
                        //ErrorMessage = $"An error occurred: {ex.Message}",
                        ErrorMessage = message,
                        RequestId = HttpContext.TraceIdentifier
                    };
                    return View("Error", errorModel);
                }
                else
                {
                    List<Category> dbCategoriesList = _repositoryCategory.GetAll();
                    List<SelectListItem> selectListItem = new List<SelectListItem>();
                    foreach(Category category in dbCategoriesList)
                    {
                        selectListItem.Add(new SelectListItem
                        {
                            Value = category.Id.ToString(),
                            Text = category.Name,
                            Selected = pictureToEdit.Categories.Any(categoryAssociated => categoryAssociated.Id == category.Id)
                        });
                    }

                    PictureFormModel model = new PictureFormModel
                    {
                        Picture = pictureToEdit,
                        Categories = selectListItem,
                    };
                    return View("Update",model);
                }

            }
            catch(Exception ex)
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

        // POST: PictureController/Edit/5
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, PictureFormModel formModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    // now I initialize a new empty list
                    List<SelectListItem> allCategoriesSelectList = new List<SelectListItem>();
                    // and I fill it with all the categorys because I want to show them in the form again if the form is not filled well so the user can input them again

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

                    formModel.Categories = allCategoriesSelectList;

                    return View("Update", formModel);
                }

                bool result = _repositoryPicture.ModifyEntity(id, formModel);
                if (!result)
                {
                    string message = "There was a problem in updating the picture";
                    var errorModel = new ErrorViewModel
                    {
                        
                        ErrorMessage = message,
                        RequestId = HttpContext.TraceIdentifier
                    };
                    return View("Error", errorModel);
                }

                return RedirectToAction("Index");

            }
            catch(Exception ex) 
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

        // GET: PictureController/Delete/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = _repositoryPicture.DeleteEntity(id);
                if (!result)
                {
                    string message = "There was a problem in deleting the picture";
                    var errorModel = new ErrorViewModel
                    {

                        ErrorMessage = message,
                        RequestId = HttpContext.TraceIdentifier
                    };
                    return View("Error", errorModel);
                }

                return RedirectToAction("Index");

            }
            catch(Exception ex ) {
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
