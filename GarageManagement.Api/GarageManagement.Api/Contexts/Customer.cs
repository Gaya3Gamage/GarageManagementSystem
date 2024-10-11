using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Api.Contexts;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Nid { get; set; } = null!;
}
