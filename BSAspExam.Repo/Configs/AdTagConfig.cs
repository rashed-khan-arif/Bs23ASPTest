using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class AdTagConfig : IEntityTypeConfiguration<AdTag>
    {
        public void Configure(EntityTypeBuilder<AdTag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.AdvertisementId);
            builder.Property(x => x.TagId);


            builder.HasOne(a => a.Advertisement).WithMany(a => a.Tags).HasForeignKey(a => a.AdvertisementId);
            builder.HasOne(a => a.Tag).WithMany(a => a.Tags).HasForeignKey(a => a.TagId);

            builder.ToTable("AdTags", "Ad");
        }
    }
}
