using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Proiect.Models;
using System.Security.Policy;

namespace Miclea_Adela_Proiect.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) :
       base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandProducer> BrandProducers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer"); // configureaza aspecte specifice cume mapele de tabele, chei primare
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Producer>().ToTable("Producer");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<BrandProducer>().ToTable("BrandProducer");
            modelBuilder.Entity<BrandProducer>()
            .HasKey(c => new { c.ProducerID, c.BrandID });
        }
    }

}
