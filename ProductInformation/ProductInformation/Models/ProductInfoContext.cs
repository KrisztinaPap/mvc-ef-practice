using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProductInformation.Models
{
    public class ProductInfoContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                string connection =
                        "server=localhost;" +
                        "port=3306;" +
                        "user=root;" +
                        "database=mvc_productinfo;";
                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                        .HasCharSet("utf8mb4")
                        .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Category()
                    {
                        ID = -1,
                        Name = "Utencil"
                    },
                    new Category()
                    {
                        ID = -2,
                        Name = "Stationary"
                    },
                    new Category()
                    {
                        ID = -3,
                        Name = "Paint"
                    });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                string keyToCategory = "FK_" + nameof(Product) +
                                 "_" + nameof(Category);

                entity.Property(e => e.Name)
                        .HasCharSet("utf8mb4")
                        .HasCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.CategoryID)
                    .HasName(keyToCategory);

                entity.HasOne(thisEntity => thisEntity.Category)
                    .WithMany(parent => parent.Products)
                    .HasForeignKey(thisEntity => thisEntity.CategoryID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName(keyToCategory);

                entity.HasData(
                    new Product()
                    {
                        ID = -1,
                        Name = "Spoon",
                        CategoryID = -1
                    },
                    new Product()
                    {
                        ID = -2,
                        Name = "Knife",
                        CategoryID = -1
                    },
                    new Product()
                    {
                        ID = -3,
                        Name = "Ladle",
                        CategoryID = -1
                    },
                    new Product()
                    {
                        ID = -4,
                        Name = "Paper",
                        CategoryID = -2
                    },
                    new Product()
                    {
                        ID = -5,
                        Name = "Notebook",
                        CategoryID = -2
                    });
            });
        }
    }
}
