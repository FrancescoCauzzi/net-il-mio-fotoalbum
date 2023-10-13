using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.DatabaseModels;


namespace net_il_mio_fotoalbum.Database
{
    public class RepositoryPicture : IRepository<Picture, PictureFormModel>
    {
        private FotoAlbumContext _db;

        public RepositoryPicture(FotoAlbumContext myDb)
        {
            _db = myDb;
        }

        public bool AddEntity(PictureFormModel formModel)
        {
            try
            {
                formModel.Picture.Categories = new List<Category>();
                if (formModel.SelectedCategoriesId != null)
                {
                    foreach (string CategorieselectedId in formModel.SelectedCategoriesId)
                    {
                        // down here I need to transform the string into an integer because the database stores the id as an integer but the form send it as a string
                        int intCategorieselectedId = int.Parse(CategorieselectedId);
                        // down here I get the Category from the database matching the id of the selected Category
                        Category? CategoryInDb = _db.Categories.Where(Category => Category.Id == intCategorieselectedId).FirstOrDefault();
                        //Category? CategoryInDb = _db.Categories.SingleOrDefault(Category => Category.Id == intCategorieselectedId);

                        // after a control for null value I add it to the list of Categories of the Picture
                        if (CategoryInDb != null)
                        {
                            formModel.Picture.Categories.Add(CategoryInDb);
                        }
                    }
                }
                Picture newPicture = new()
                {
                    Name = formModel.Picture.Name,
                    Description = formModel.Picture.Description,
                    IsVisible = formModel.Picture.IsVisible,
                    Categories = formModel.Picture.Categories,
                    ImageFile = GetImageFileFromFormFile(formModel.ImageFormFile),
                    MimeType = formModel.ImageFormFile.ContentType
                };

                _db.Pictures.Add(newPicture);
                _db.SaveChanges();


                return true;

            }
            catch
            {
                // Log the exception (assuming you have a logger set up)
                //_logger.LogError(ex, "Failed to add picture");
                return false;
            }          
        }

        private byte[] GetImageFileFromFormFile(IFormFile formFile)
        {
            if (formFile == null)
            {
                return Array.Empty<byte>();
            }

            using (MemoryStream stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                return stream.ToArray();
            }
        }

        public bool DeleteEntity(int id)
        {

            Picture? pictureToDelete = _db.Pictures.Where(p => p.Id == id).FirstOrDefault();

            if(pictureToDelete == null)
            {
                return false;
            }
            _db.Pictures.Remove(pictureToDelete);
            _db.SaveChanges();
            return true;
    }

        public Picture GetEntityById(int id)
        {
            Picture? picture = _db.Pictures.Where(Picture => Picture.Id == id).Include(Picture => Picture.Categories).FirstOrDefault();
            if(picture == null)
            {
                throw new Exception("This picture could not be found");
            }
            return picture;
        }

        public List<Picture> GetEntities(string name)
        {
            List<Picture> foundPictures = _db.Pictures
                 .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                 .ToList();
            return foundPictures;
        }

        public bool ModifyEntity(int id, PictureFormModel formModel)
        {
            Picture? pictureToUpdate = _db.Pictures.Where(Picture => Picture.Id == id).Include(Picture => Picture.Categories).FirstOrDefault();
            if(pictureToUpdate == null)
            {
                return false;
            }
            else
            {

                    pictureToUpdate.Categories.Clear();
                    pictureToUpdate.Name = formModel.Picture.Name;
                    pictureToUpdate.Description = formModel.Picture.Description;
                    pictureToUpdate.IsVisible = formModel.Picture.IsVisible;
                    pictureToUpdate.ImageFile = GetImageFileFromFormFile(formModel.ImageFormFile);
                    pictureToUpdate.MimeType = formModel.ImageFormFile.ContentType;
                
                foreach (string CategorieselectedId in formModel.SelectedCategoriesId)
                {
                    // down here I need to transform the string into an integer because the database stores the id as an integer but the form send it as a string
                    int intCategorieselectedId = int.Parse(CategorieselectedId);
                    // down here I get the Category from the database matching the id of the selected Category
                    Category? CategoryInDb = _db.Categories.Where(Category => Category.Id == intCategorieselectedId).FirstOrDefault();
                    //Category? CategoryInDb = _db.Categories.SingleOrDefault(Category => Category.Id == intCategorieselectedId);

                    // after a control for null value I add it to the list of Categories of the Picture
                    if (CategoryInDb != null)
                    {
                        pictureToUpdate.Categories.Add(CategoryInDb);
                    }
                }
            }           

            
            _db.SaveChanges();


            return true;

        }       

        public List<Picture> GetAll()
        {
            return _db.Pictures.ToList();
        }
    }
}
