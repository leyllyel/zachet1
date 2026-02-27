using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prac1.Models;

[Table("suppliers")]
[Index("SuplierName", Name = "suppliers_suplier_name_key", IsUnique = true)]
public partial class Supplier
{
    [Key]
    [Column("suplier_id")]
    public int SuplierId { get; set; }

    [Column("suplier_name")]
    [StringLength(100)]
    public string SuplierName { get; set; } = null!;

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
