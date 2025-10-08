using BOOTSHOP.Models.Data.BOOTSHOPContext;
using BOOTSHOP.Models.Data.Services;
using BOOTSHOP.Models.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOTSHOP.Controllers
{
    public class ProductCategoryController : Controller
    {

        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoryController(ProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // GET: ProductCategoryController
        public ActionResult Index()
        {
            var model = _productCategoryService.GetProductCategories();
            return View(model);
        }

        // GET: ProductCategoryController/Details/5
        public ActionResult Details(int id)
        {
            var model = _productCategoryService.GetProductCategory(id);
            return View(model);
        }

        // GET: ProductCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategoryViewModel model)
        {
            try
            {
                bool result = _productCategoryService.AddProductCategory(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("Failed to add product category");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ProductCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _productCategoryService.GetProductCategory(id);
            return View(model);
        }

        // POST: ProductCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategoryViewModel model)
        {
            try
            {
                bool result = _productCategoryService.UpdateProductCategory(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("Failed to update product category");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ProductCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _productCategoryService.GetProductCategory(id);
            return View(model);
        }

        // POST: ProductCategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool result = _productCategoryService.DeleteProductCategory(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("Failed to delete product category");
            }
            catch (Exception)
            {
                return View();
            }
        }


    }
}
