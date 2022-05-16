using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShopEasy.Core;

namespace ShopEasy.Infrastructure
{
    /// <summary>
    /// Context used by EF Core to communicate with database
    /// </summary>
    public partial class ShopEasyDBContext : DbContext
    {
        public ShopEasyDBContext()
        {
        }

        public ShopEasyDBContext(DbContextOptions<ShopEasyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ShopEasyDB"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Admin__1788CC4CB79B3F0D");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin__UserId__3F115E1A");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("UQ__Customer__49A147404D392D39")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("UQ__Customer__85FB4E382D2A2E97")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customers)
                    .HasForeignKey<Customers>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Id__793DFFAF");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__Custom__1B9317B3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__Produc__1C873BEC");
            });

            modelBuilder.Entity<ProductCategories>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.ParentId })
                    .HasName("UQ__ProductC__9E4611E032BFB900")
                    .IsUnique();

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__ProductCa__Paren__351DDF8C");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Products__737584F6CD7117EA")
                    .IsUnique();

                entity.Property(e => e.SubCategory).HasDefaultValueSql("('N/A')");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F284566D1CBCF4")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
