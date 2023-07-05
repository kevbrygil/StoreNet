using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreNet.Domain.Entities;

namespace StoreNet.Infrastructure
{
    public partial class StoreNetContext : DbContext
    {
        public StoreNetContext()
        {
        }

        public StoreNetContext(DbContextOptions<StoreNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductStore> ProductStores { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=localhost,14333;Initial Catalog=StoreNet;Persist Security Info=True;User ID=sa;Password=P@ssword;MultipleActiveResultSets=True; Integrated Security=false;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07E8E4DE9F");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0733248663");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Price)
                    .HasDefaultValueSql("((0.00))")
                    .HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<ProductStore>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("ProductStore");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store).WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer).WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product).WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Stores__3214EC07C88D5815");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Branch)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
