using Microsoft.EntityFrameworkCore;
using prac1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac1.Context
{
    public partial class PostgresContext : DbContext
    {
        public PostgresContext()
        {
        }

        public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=postgres;Username=postgres;password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId).HasName("addresses_pkey");

                entity.ToTable("addresses");

                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .HasColumnName("address");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("category_pkey");

                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.ManufactureId).HasName("manufacturer_pkey");

                entity.ToTable("manufacturer");

                entity.Property(e => e.ManufactureId).HasColumnName("manufacturer_id");
                entity.Property(e => e.ManufactureName)
                    .HasMaxLength(100)
                    .HasColumnName("manufacturer_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("orders_pkey");

                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
                entity.Property(e => e.OrderDate).HasColumnName("order_date");
                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(20)
                    .HasColumnName("order_number");
                entity.Property(e => e.PickupCode)
                    .HasMaxLength(10)
                    .HasColumnName("pickup_code");
                entity.Property(e => e.StatusId).HasColumnName("status_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Address).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("orders_address_id_fkey");

                entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("orders_status_id_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("orders_user_id_fkey");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId).HasName("order_items_pkey");

                entity.ToTable("order_items");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("order_items_order_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("order_items_product_id_fkey");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId).HasName("order_statuses_pkey");

                entity.ToTable("order_statuses");

                entity.Property(e => e.StatusId).HasColumnName("status_id");
                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("products_pkey");

                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Article)
                    .HasMaxLength(255)
                    .HasColumnName("article");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Discount)
                    .HasPrecision(5, 2)
                    .HasColumnName("discount");
                entity.Property(e => e.ManufactureId).HasColumnName("manufacturer_id");
                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(255)
                    .HasColumnName("photo_path");
                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                entity.Property(e => e.Unit)
                    .HasMaxLength(28)
                    .HasColumnName("unit");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("products_category_id_fkey");

                entity.HasOne(d => d.Manufacture).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufactureId)
                    .HasConstraintName("products_manufacturer_id_fkey");

                entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("products_supplier_id_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("roles_pkey");

                entity.ToTable("roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.RoleName).HasColumnName("role");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SuplierId).HasName("supplier_pkey");

                entity.ToTable("supplier");

                entity.Property(e => e.SuplierId).HasColumnName("supplier_id");
                entity.Property(e => e.SuplierName)
                    .HasMaxLength(100)
                    .HasColumnName("supplier_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Name).HasColumnName("fio");
                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("users_role_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
