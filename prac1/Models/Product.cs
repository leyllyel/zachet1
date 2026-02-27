using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prac1.Models;

[Table("products")]
[Index("Article", Name = "products_article_key", IsUnique = true)]
public partial class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("article")]
    [StringLength(20)]
    public string Article { get; set; } = null!;

    [Column("product_name")]
    [StringLength(200)]
    public string ProductName { get; set; } = null!;

    [Column("unit")]
    [StringLength(10)]
    public string Unit { get; set; } = null!;

    [Column("price")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    [Column("supplier_id")]
    public int SupplierId { get; set; }

    [Column("manufacture_id")]
    public int ManufactureId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("discount")]
    public int? Discount { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("photo_path")]
    [StringLength(100)]
    public string? PhotoPath { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("ManufactureId")]
    [InverseProperty("Products")]
    public virtual Manufacturer Manufacture { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Products")]
    public virtual Supplier Supplier { get; set; } = null!;
}
