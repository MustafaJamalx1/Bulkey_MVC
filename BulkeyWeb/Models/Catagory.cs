using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace BulkeyWeb.Models
{
    public class Catagory
    {
        [Key]
        public int CatagoreyId { get; set; }
        [Required]
        [DisplayName("Catagory Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
