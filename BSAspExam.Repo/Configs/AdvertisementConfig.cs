using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class AdvertisementConfig : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Active);
            builder.Property(x => x.Status);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.LocationId);
            builder.Property(x => x.Verified);
            builder.Property(x => x.Slug);
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.ToTable("Advertisements", "Ad");
        }
    }
}
