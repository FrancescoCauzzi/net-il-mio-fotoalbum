using net_il_mio_fotoalbum.Models.DatabaseModels;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Database
{
    public class RepositoryContact : IRepository<Contact, ContactFormModel>
    {
        private FotoAlbumContext _db;

        public RepositoryContact(FotoAlbumContext myDb)
        {
            _db = myDb;
        }

        public bool AddEntity(ContactFormModel formModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetEntities(string criteria)
        {
            throw new NotImplementedException();
        }

        public Contact GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ModifyEntity(int id, ContactFormModel formModel)
        {
            throw new NotImplementedException();
        }

        public bool AddEntity(Contact entity)
        {
            try
            {
                Contact newContact = new()
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    Message = entity.Message,
                    Subject = entity.Subject,
                    
                };

                _db.Contacts.Add(newContact);
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
