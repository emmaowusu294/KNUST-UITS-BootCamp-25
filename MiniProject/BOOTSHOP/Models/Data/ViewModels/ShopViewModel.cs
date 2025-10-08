using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BOOTSHOP.Models.Data.ViewModels
{
    public class ShopViewModel
    {
        [Key]
        public int ShopId { get; set; }

        [DisplayName("Shop Name")]
        [Required(ErrorMessage = "Shop name is required.")]
        public string ShopName { get; set; } = null!;

        [DisplayName("Shop Location")]
        [Required(ErrorMessage = "Shop location is required.")]
        public string ShopLocation { get; set; } = null!;
    }
}
