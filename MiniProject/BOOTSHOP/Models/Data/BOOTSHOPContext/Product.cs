using System;
using System.Collections.Generic;

namespace BOOTSHOP.Models.Data.BOOTSHOPContext;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int SerialNumber { get; set; }

    public int ShopId { get; set; }

    public int ProductCategoryId { get; set; }

    public int ProductImageId { get; set; }

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ProductImage ProductImage { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
