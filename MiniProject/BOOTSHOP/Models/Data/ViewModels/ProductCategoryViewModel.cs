using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BOOTSHOP.Models.Data.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [DisplayName("Product Category")]
        [Required(ErrorMessage = "Product Category is required.")]
        public string ProductCategoryName { get; set; } = null!;
    }
}
