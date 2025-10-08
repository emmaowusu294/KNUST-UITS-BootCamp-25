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
        public List<ViewModels.ProductCategoryViewModel> GetProductCategories()
        {
            List<ProductCategory> productCategories = _context.ProductCategories.ToList();

            if (productCategories == null) 
            { 
                return new List<ViewModels.ProductCategoryViewModel>();
            }

            List<ViewModels.ProductCategoryViewModel> model = productCategories.Select(x => new ProductCategoryViewModel
            {
                ProductCategoryId = x.ProductCategoryId,
                ProductCategoryName = x.ProductCategoryName
            }).ToList();

            return model;
        }

        //FETCH ONLY ONE PRODUCT CATEGORY USING THE ID
        public ProductCategoryViewModel GetProductCategory(int productCategoryId)
        {
            ProductCategory? productCategory = _context.ProductCategories
                                               .Where(x => x.ProductCategoryId == productCategoryId)
                                               .FirstOrDefault();

            if (productCategory == null)
            {
                return new ProductCategoryViewModel();
            }
            
            ProductCategoryViewModel model = new ProductCategoryViewModel
            {
                ProductCategoryId = productCategory.ProductCategoryId,
                ProductCategoryName = productCategory.ProductCategoryName
            };

            return model;
        }

        // ADD PRODUCT CATEGORY
        public bool AddProductCategory(ProductCategoryViewModel model)
        {
     
                ProductCategory productCategory = new ProductCategory
                {
                    ProductCategoryName = model.ProductCategoryName
                };
                
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
            return true;

        }

        // UPDATE PRODUCT CATEGORY USING ITS ID
        public bool UpdateProductCategory(ProductCategoryViewModel model)
        {
            ProductCategory? productCategory = _context.ProductCategories
                                                .Where(x => x.ProductCategoryId == model.ProductCategoryId)
                                                .FirstOrDefault();
            if (productCategory == null)
            {
                return false;
            }
            productCategory.ProductCategoryName = model.ProductCategoryName;
            _context.ProductCategories.Update(productCategory);
            _context.SaveChanges();
            return true;
        }

        // DELETE PRODUCT CATEGOTY 
        public bool DeleteProductCategory(int productCategoryId)
        {
            ProductCategory? productCategory = _context.ProductCategories
                                                .Where(x => x.ProductCategoryId == productCategoryId)
                                                .FirstOrDefault();
            if (productCategory == null)
            {
                return false;
            }
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
            return true;
        }

    }
}
