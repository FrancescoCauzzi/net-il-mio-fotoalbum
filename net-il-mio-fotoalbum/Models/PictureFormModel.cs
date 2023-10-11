
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using net_il_mio_fotoalbum.Models.DatabaseModels;

namespace net_il_mio_fotoalbum.Models
{
    public class PictureFormModel
    {
        public Picture Picture { get; set; }

        public IFormFile ImageFormFile { get; set; }

        // We insert new properties to manage the selection in the views
        public List<SelectListItem>? Categories { get; set; }

        public List<string>? SelectedCategoriesId { get; set; }
    }
}
