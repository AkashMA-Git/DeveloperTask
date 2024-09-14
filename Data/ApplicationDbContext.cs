using DeveloperTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                  new User { UserID = 1001, Email = "skanth@gmail.com", Password = "1234" },
                  new User { UserID= 1002, Email = "idumban@gmail.com", Password = "1234"},
                  new User { UserID = 1003, Email = "muru@gmail.com", Password = "1234" });


            modelBuilder.Entity<Product>().HasData(
                 new Product { ProductId = 1, ProductName = "Pen", Price = 25,Quantity= 5},
                 new Product { ProductId = 2, ProductName = "Ball", Price = 1000, Quantity=10 },
                 new Product { ProductId = 3, ProductName = "Pencil", Price = 12 , Quantity =4});
        }

   
    }
}
