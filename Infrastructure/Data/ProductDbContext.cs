using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    internal class ProductDbContext : IdentityDbContext<User>
    {
        public ProductDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.SeedUser();
            modelBuilder.SeedCategory();
            modelBuilder.SeedProduct();
            //modelBuilder.SeedFavorite();
            //modelBuilder.SeedBasket();


            modelBuilder.ApplyConfiguration(new ProductConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=shopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //optionsBuilder.UseSqlServer(connStr);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}