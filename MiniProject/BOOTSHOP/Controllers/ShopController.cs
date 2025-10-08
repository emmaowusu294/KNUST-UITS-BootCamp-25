using BOOTSHOP.Models.Data.Services;
using BOOTSHOP.Models.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOTSHOP.Controllers
{
    public class ShopController : Controller
    {

        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: ShopController
        public ActionResult Index()
        {
            var model = _shopService.GetShops();
            return View(model);
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            var model = _shopService.GetShop(id);
            return View(model);
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopViewModel model)
        {
            try
            {
                bool result = _shopService.AddShop(model);  
               if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("Failed to add shop");
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _shopService.GetShop(id);
            return View(model);
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopViewModel model)
        {

            try
            {
                bool result = _shopService.UpdateShop(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("Failed to update shop");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _shopService.GetShop(id);
            return View(model);
        }

        // POST: ProductCategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool result = _shopService.DeleteShop(id);
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
