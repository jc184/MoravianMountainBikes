using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoravianMountainBikes.Models
{
    public partial class MoravianContext : DbContext
    {
        public MoravianContext()
        {
        }

        public MoravianContext(DbContextOptions<MoravianContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M6282RS;Initial Catalog=Moravian;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category", "moravian");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer", "moravian");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Addressline1)
                    .IsRequired()
                    .HasColumnName("addressline1")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Addressline2)
                    .IsRequired()
                    .HasColumnName("addressline2")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Creditcardexpiry)
                    .IsRequired()
                    .HasColumnName("creditcardexpiry")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Creditcardnumber)
                    .IsRequired()
                    .HasColumnName("creditcardnumber")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Creditcardtype)
                    .IsRequired()
                    .HasColumnName("creditcardtype")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Emailaddress)
                    .IsRequired()
                    .HasColumnName("emailaddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loginpassword)
                    .IsRequired()
                    .HasColumnName("loginpassword")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("postcode")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("customer_order", "moravian");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_order_customer1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ConfirmationNumber).HasColumnName("confirmation_number");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("datetime2(0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customer_order$fk_customer_order_customer");
            });

            modelBuilder.Entity<OrderedProduct>(entity =>
            {
                entity.HasKey(e => new { e.CustomerOrderId, e.ProductCode });

                entity.ToTable("ordered_product", "moravian");

                entity.HasIndex(e => e.CustomerOrderId)
                    .HasName("fk_ordered_product_customer_order_idx");

                entity.HasIndex(e => e.ProductCode)
                    .HasName("fk_ordered_product_product_idx");

                entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");

                entity.Property(e => e.ProductCode).HasColumnName("product_code");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.OrderedProduct)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("ordered_product$fk_ordered_product_customer_order");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.OrderedProduct)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ordered_product_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("product", "moravian");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_product_category1_idx");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("product$fk_product_category1");
            });
        }
    }
}
