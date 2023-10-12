﻿using net_il_mio_fotoalbum.Models.DatabaseModels;
using net_il_mio_fotoalbum.Models;

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
            throw new NotImplementedException();
        }

        public bool DeleteEntity(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool ModifyEntity(int id, CategoryFormModel formModel)
        {
            throw new NotImplementedException();
        }
    }
}