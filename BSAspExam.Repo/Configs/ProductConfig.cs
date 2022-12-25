using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repo.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.CategoryId);
            builder.Property(x => x.BrandId);
            builder.Property(x => x.Description);
            builder.Property(x => x.Active); 
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");

            builder.HasOne(a => a.Advertisement).WithOne(a => a.Product).HasForeignKey<Advertisement>(a => a.ProductId);
            builder.HasOne(a => a.Brand).WithMany(a => a.Products).HasForeignKey(a => a.Brand);
            builder.HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryId);

            builder.ToTable("Products", "Prod");
        }
    }
}
