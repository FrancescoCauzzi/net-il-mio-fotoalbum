using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.DatabaseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_il_mio_fotoalbum.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private IRepository<Picture, PictureFormModel> _repositoryPicture;
        private IRepository<Category, CategoryFormModel> _repositoryCategory;


        public PicturesController(IRepository<Picture, PictureFormModel> repositoryPicture, IRepository<Category, CategoryFormModel> repositoryCategory)
        {
            _repositoryPicture = repositoryPicture;
            _repositoryCategory = repositoryCategory;
        }

        
        // GET: api/<PicturesController>
        [HttpGet]
        public IActionResult GetAllPictures()
        {
            List<Picture> pictureList = _repositoryPicture.GetAll();
            return Ok(pictureList);
        }

        // GET api/<PicturesController>/5
        [HttpGet("{id}")]
        public IActionResult GetPictureById(int id)
        {
            Picture picture = _repositoryPicture.GetEntityById(id);

            if (picture != null)
            {
                return Ok(picture);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult SearchPictures(string? search)
        {
            List<Picture> foundedPictures = new List<Picture>();
            if (search == null)
            {
                foundedPictures = _repositoryPicture.GetAll();
            }
            else
            {
                foundedPictures = _repositoryPicture.GetEntities(search);
            }

            return Ok(foundedPictures);

        }

        // here we start the POST requests,they are not necessary for the exercise, they could be implemented later
        // add a new picture to the db

        // POST api/<PicturesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PicturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PicturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
