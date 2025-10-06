using System;
using System.Collections.Generic;

namespace BOOTSHOP.Models.Data.BOOTSHOPContext;

public partial class Shop
{
    public int ShopId { get; set; }

    public string ShopName { get; set; } = null!;

    public string ShopLocation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SalesPerson> SalesPeople { get; set; } = new List<SalesPerson>();
}
