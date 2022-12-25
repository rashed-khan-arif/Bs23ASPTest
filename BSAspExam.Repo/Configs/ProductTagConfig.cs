using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class ProductTagConfig : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId); 
            builder.Property(x => x.TagId); 
            builder.Property(x => x.Active);


            builder.HasOne(a => a.Product).WithMany(a => a.Tags).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Tag).WithMany(a => a.ProductTags).HasForeignKey(a => a.TagId);


            builder.ToTable("ProductTags", "Prod");
        }
    } 
}
