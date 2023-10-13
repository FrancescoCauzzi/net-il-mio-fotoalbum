using net_il_mio_fotoalbum.Models.DatabaseModels;
using net_il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Routing.Tree;

namespace net_il_mio_fotoalbum.Database
{
    public class RepositoryCategory : IRepository<Category, CategoryFormModel>
    {
        private FotoAlbumContext _db;

        public RepositoryCategory(FotoAlbumContext myDb)
        {
            _db = myDb;
        }
        public bool AddEntity(CategoryFormModel formModel)
        {
            try
            {
                Category newCategory = new()
                {
                    Name = formModel.Category.Name
                };
                _db.Categories.Add(newCategory);
                _db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEntity(int id)
        {
            Category? categoryToDelete = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (categoryToDelete == null) { 
                return false;            
            }
            _db.Categories.Remove(categoryToDelete);
            _db.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public List<Category> GetEntities(string criteria)
        {
            throw new NotImplementedException();
        }

        public Category GetEntityById(int id)
        {
            Category? category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                return category;

            }
            else
            {
                throw new Exception("This category has not been found");
            }
        }

        public bool ModifyEntity(int id, CategoryFormModel formModel)
        {
            throw new NotImplementedException();
        }

        public bool AddEntity(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
