using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class AdContactInfoConfig : IEntityTypeConfiguration<AdContactInfo>
    {
        public void Configure(EntityTypeBuilder<AdContactInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AdvertisementId);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Name);
            builder.Property(x => x.Email);
            builder.ToTable("AdContactInfos", "Ad");
        }
    }
}
