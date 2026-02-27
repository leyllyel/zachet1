using Microsoft.EntityFrameworkCore;

namespace prac1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=1234");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}