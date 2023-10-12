using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.DatabaseModels;
using System.Diagnostics;

namespace net_il_mio_fotoalbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository<Picture, PictureFormModel> _repositoryPicture;

        public HomeController(ILogger<HomeController> logger, IRepository<Picture, PictureFormModel> repositoryPicture)
        {
            _logger = logger;
            _repositoryPicture = repositoryPicture;
        }

        public IActionResult Index()
        {
            try
            {
                List<Picture> pictures = _repositoryPicture.GetAll();
                return View("Index", pictures);

            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    
                    ErrorMessage = ex.Message,
                    RequestId = HttpContext.TraceIdentifier 
                };
                return View("Error", errorModel);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HomeGetPicturesByName(string search)
        {
            try
            {
                List<Picture> foundPictures = new();
                if (search == null)
                {
                    foundPictures = _repositoryPicture.GetAll();
                    return View("Index", foundPictures);

                }

                foundPictures = _repositoryPicture.GetEntities(search!);
                return View("Index", foundPictures);                            
                
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {                    
                    ErrorMessage = ex.Message,
                    RequestId = HttpContext.TraceIdentifier 
                };
                return View("Error", errorModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}