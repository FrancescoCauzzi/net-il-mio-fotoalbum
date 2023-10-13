using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace net_il_mio_fotoalbum.Models.DatabaseModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        [MaxLength(100, ErrorMessage = $"The name must not exceed 100 characters")]
        public string Name { get; set; }

        // relation N:N with Picture
        [JsonIgnore]
        public List<Picture>? Pictures { get; set; }

        // empty constructor
        public Category() { 
        }
    }
}
