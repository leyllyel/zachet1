using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prac1.Models;

[Table("addresses")]
[Index("Address1", Name = "addresses_address_key", IsUnique = true)]
public partial class Address
{
    [Key]
    [Column("address_id")]
    public int AddressId { get; set; }

    [Column("address")]
    public string Address1 { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
