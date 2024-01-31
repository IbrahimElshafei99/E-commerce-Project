using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .HasOne(s=> s.Customer)
                        .WithMany(o=> o.Orders)
                        .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<OrderItems>()
                        .HasOne(s => s.Order)
                        .WithMany(o=> o.OrderItems)
                        .HasForeignKey(i => i.Order_Id);

            modelBuilder.Entity<OrderItems>()
                        .HasOne(s => s.Product)
                        .WithMany(o => o.OrderItems)
                        .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Category>()
                        .HasMany(p=> p.Products)
                        .WithOne(c=> c.Category)
                        .HasForeignKey(c=> c.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItems> ordersItems { get; set; } 
    }
    

}
