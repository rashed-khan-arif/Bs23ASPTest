using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class AdImageConfig : IEntityTypeConfiguration<AdImage>
    {
        public void Configure(EntityTypeBuilder<AdImage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.AdvertisementId);
            builder.Property(x => x.ImageId);
            builder.ToTable("AdImages", "Ad");
        }
    }
}
