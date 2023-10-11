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
            throw new NotImplementedException();
        }

        public Picture GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Picture> GetEntities(string title)
        {
            throw new NotImplementedException();
        }

        public bool ModifyEntity(int id, PictureFormModel formModel)
        {
            throw new NotImplementedException();
        }
    }
}
