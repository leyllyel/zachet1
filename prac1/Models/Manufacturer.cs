using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prac1.Models;

[Table("manufacturers")]
[Index("ManufactureName", Name = "manufacturers_manufacture_name_key", IsUnique = true)]
public partial class Manufacturer
{
    [Key]
    [Column("manufacture_id")]
    public int ManufactureId { get; set; }

    [Column("manufacture_name")]
    [StringLength(100)]
    public string ManufactureName { get; set; } = null!;

    [InverseProperty("Manufacture")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
