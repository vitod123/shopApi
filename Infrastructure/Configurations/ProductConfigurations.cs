using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Category).WithMany(m => m.Products).HasForeignKey(c => c.CategoryId);
            builder.HasMany(p => p.Favorites).WithOne(f => f.Product).HasForeignKey(f => f.ProductId);
            builder.HasMany(p => p.Baskets).WithOne(b => b.Product).HasForeignKey(b => b.ProductId);
        }
    }
}