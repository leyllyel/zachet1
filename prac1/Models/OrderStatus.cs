using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prac1.Models;

[Table("order_statuses")]
[Index("StatusName", Name = "order_statuses_status_name_key", IsUnique = true)]
public partial class OrderStatus
{
    [Key]
    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("status_name")]
    [StringLength(50)]
    public string StatusName { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
