using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId); 
            builder.Property(x => x.ImageId); 
            builder.Property(x => x.Active);


            builder.HasOne(a => a.Product).WithMany(a => a.ProductImages).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Image).WithMany(a => a.ProductImages).HasForeignKey(a => a.ImageId);



            builder.ToTable("ProductImages", "Prod");
        }
    } 
}
