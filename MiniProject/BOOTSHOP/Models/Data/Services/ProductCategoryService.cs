using BOOTSHOP.Models.Data.BOOTSHOPContext;
using BOOTSHOP.Models.Data.ViewModels;

namespace BOOTSHOP.Models.Data.Services
{
    public class ProductCategoryService
    {
        private BOOTSHOPContext.BootshopContext _context;
      

        public ProductCategoryService(BOOTSHOPContext.BootshopContext context)
        {
            _context = context;
        }

        // GET ALL PRODUCT CATEGORIES
        public List<ProductCategoryViewModel> GetAllProductCategories()
        {
            List<ProductCategory> productCategories = _context.ProductCategories.ToList();

            if (productCategories == null) 
            { 
                return new List<ProductCategoryViewModel>();
            }

            List<ProductCategoryViewModel> model = productCategories.Select(x => new ProductCategoryViewModel
            {
                ProductCategoryId = x.ProductCategoryId,
                ProductCategoryName = x.ProductCategoryName
            }).ToList();

            return model;
        }

        //FETCH ONLY ONE PRODUCT CATEGORY USING THE ID
    }
}
