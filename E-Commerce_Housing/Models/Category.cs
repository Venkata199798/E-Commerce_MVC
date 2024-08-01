using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Housing.Models
{
    //Columns in the Category Table
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Category Order")]
        [Range(1,100,ErrorMessage ="Display Order Must be Between 1-100.")]
        public int DisplayOrder { get; set; }

    }
}
