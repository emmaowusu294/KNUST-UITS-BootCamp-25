using System;
using System.Collections.Generic;

namespace BOOTSHOP.Models.Data.BOOTSHOPContext;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
