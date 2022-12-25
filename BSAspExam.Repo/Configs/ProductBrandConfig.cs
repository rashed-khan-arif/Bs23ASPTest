using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class ProductBrandConfig : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name); 
            builder.Property(x => x.Description); 
            builder.Property(x => x.Active);  


            builder.ToTable("ProductBrands", "Prod");
        }
    }
}
