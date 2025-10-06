using System;
using System.Collections.Generic;

namespace BOOTSHOP.Models.Data.BOOTSHOPContext;

public partial class SalesPerson
{
    public int SalesPersonId { get; set; }

    public string Surname { get; set; } = null!;

    public string OtherName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int ShopId { get; set; }

    public virtual Shop Shop { get; set; } = null!;
}
