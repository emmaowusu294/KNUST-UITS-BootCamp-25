using BOOTSHOP.Models.Data.BOOTSHOPContext;
using BOOTSHOP.Models.Data.ViewModels;

namespace BOOTSHOP.Models.Data.Services
{
    public class ShopService
    {
        private readonly BOOTSHOPContext.BootshopContext _context;

        public ShopService(BOOTSHOPContext.BootshopContext context)
        {
            _context = context;
        }

        // GET ALL SHOPS

        public List<ShopViewModel> GetShops()
        {
            List<Shop> shops = _context.Shops.ToList();
            if (shops == null) 
            { 
                return new List<ViewModels.ShopViewModel>();
            }
            List<ViewModels.ShopViewModel> model = shops.Select(x => new ViewModels.ShopViewModel
            {
                ShopId = x.ShopId,
                ShopName = x.ShopName,
                ShopLocation = x.ShopLocation
            }).ToList();
            return model;
        }

        //FETCH ONLY ONE SHOP USING THE ID
        public ShopViewModel GetShop(int shopId)
        {
            Shop? shop = _context.Shops
                                               .Where(x => x.ShopId == shopId)
                                               .FirstOrDefault();
            if (shop == null)
            {
                return new ShopViewModel();
            }
            ShopViewModel model = new ShopViewModel
            {
                ShopId = shop.ShopId,
                ShopName = shop.ShopName,
                ShopLocation = shop.ShopLocation
            };
            return model;
        }

        // ADD SHOP
        public bool AddShop(ShopViewModel model)
        {
            Shop shop = new Shop
            {
                ShopName = model.ShopName,
                ShopLocation = model.ShopLocation
            };
            _context.Shops.Add(shop);
            _context.SaveChanges();
            return true;
        }

        // UPDATE SHOP USING ITS ID
        public bool UpdateShop(ShopViewModel model)
        {
            Shop? shop = _context.Shops
                                                .Where(x => x.ShopId == model.ShopId)
                                                .FirstOrDefault();
            if (shop == null)
            {
                return false;
            }
            shop.ShopName = model.ShopName;
            shop.ShopLocation = model.ShopLocation;
            _context.Shops.Update(shop);
            _context.SaveChanges();
            return true;
        }

        // DELETE SHOP
        public bool DeleteShop(int shopId)
        {
            Shop? shop = _context.Shops
                                                .Where(x => x.ShopId == shopId)
                                                .FirstOrDefault();
            if (shop == null)
            {
                return false;
            }
            _context.Shops.Remove(shop);
            _context.SaveChanges();
            return true;
        }
    }
}
