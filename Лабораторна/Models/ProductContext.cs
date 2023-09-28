using Microsoft.EntityFrameworkCore;

namespace Лабораторна.Models
{
    public class ProductContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Лосіни", Price = 330.0, Stock = 54, Description = "Some text" },
                new Product { Id = 2, Name = "Блузка", Price = 24, Stock = 144, Description = "Some text" },
                new Product { Id = 3, Name = "Лосіни", Price = 750, Stock = 24, Description = "Some text" }
            );
        }

        public ProductContext()
        {
			Database.EnsureCreated();
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=123456789;database=sundukmod;",
                new MySqlServerVersion(new Version(8, 0, 11))
                );
        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set;}
    }
}
