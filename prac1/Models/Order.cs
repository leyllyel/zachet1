using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prac1.Models;

[Table("orders")]
[Index("OrderNumber", Name = "orders_order_number_key", IsUnique = true)]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("order_number")]
    public int OrderNumber { get; set; }

    [Column("order_date")]
    public DateOnly OrderDate { get; set; }

    [Column("delivery_date")]
    public DateOnly DeliveryDate { get; set; }

    [Column("address_id")]
    public int AddressId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("pickup_code")]
    [StringLength(10)]
    public string PickupCode { get; set; } = null!;

    [Column("status_id")]
    public int StatusId { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Orders")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("StatusId")]
    [InverseProperty("Orders")]
    public virtual OrderStatus Status { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
