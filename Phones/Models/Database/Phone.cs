using System;
using System.Collections.Generic;

namespace Phones.Models.Database;

public partial class Phone
{
    public int PhoneId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? PriceType { get; set; }
}
