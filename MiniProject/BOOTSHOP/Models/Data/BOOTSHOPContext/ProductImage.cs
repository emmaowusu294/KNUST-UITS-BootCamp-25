using System;
using System.Collections.Generic;

namespace BOOTSHOP.Models.Data.BOOTSHOPContext;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public byte[] Image { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
