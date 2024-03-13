using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class WebshopContext : DbContext
    {
        public WebshopContext(DbContextOptions<WebshopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BasketPosition> BasketPositions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketPosition>()
                .HasOne(bp => bp.ProductGroup)  
                .WithMany(pg => pg.BasketPositions)
                .HasForeignKey(bp => bp.ProductGroupID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BasketPosition>()
                .HasOne(bp => bp.User)
                .WithMany(u => u.BasketPositions)
                .HasForeignKey(bp => bp.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderPosition>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderPositions)
                .HasForeignKey(op => op.OrderID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}