using net_il_mio_fotoalbum.Models.DatabaseModels;
using net_il_mio_fotoalbum.Models;
using System.Collections.Generic;


namespace net_il_mio_fotoalbum.Database
{
    /*
    public interface IRepositoryPicture
    {
        // vedere tutte quelle inserite (filtrabili)
        public List<Picture> GetPicturesByName(string title);
        // vedere i dettagli di una singola foto
        public Picture GetPictureById(int id);
        // aggiungerne di nuove (con validazione)
        public bool AddPicture(PictureFormModel formModel);
        // modificarle (con validazione)
        public bool ModifyPicture(int id, PictureFormModel formModel);
        // delete
        public bool DeletePicture(int id);
    }
    */
    public interface IRepository<T, TFormModel>
    {
        // Get entities by name (or some other criteria, which might vary by entity type)
        List<T> GetEntities(string criteria);
        // Get a single entity by ID
        T GetEntityById(int id);
        // Add a new entity (with validation)
        bool AddEntity(TFormModel formModel);
        // Modify an existing entity (with validation)
        bool ModifyEntity(int id, TFormModel formModel);
        // Delete an entity
        bool DeleteEntity(int id);
    }

}
