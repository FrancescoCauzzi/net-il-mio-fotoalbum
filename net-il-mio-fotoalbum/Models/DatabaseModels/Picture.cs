using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models.DatabaseModels
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        [MaxLength(100, ErrorMessage = $"The name must not exceed 100 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is mandatory")]
        [MaxLength(1000, ErrorMessage = $"The name must not exceed 1000 characters")]
        [Column(TypeName = "text")]        
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public bool IsVisible { get; set; }

        // relation N:N with Category
        public List<Category>? Categories { get; set; }

        // empty constructor
        public Picture()
        {

        }
    }
}
