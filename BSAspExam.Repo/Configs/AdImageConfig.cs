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

            builder.HasOne(a => a.Advertisement).WithMany(a => a.Images).HasForeignKey(a => a.AdvertisementId);
            builder.HasOne(a => a.Image).WithMany(a => a.AdImages).HasForeignKey(a => a.ImageId);

            builder.ToTable("AdImages", "Ad");
        }
    }
}
