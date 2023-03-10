using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BSAspExam.Repositories.Core;

namespace BSAspExam.Repositories.Configs
{
    public class AdMessageConfig : IEntityTypeConfiguration<AdMessage>
    {
        public void Configure(EntityTypeBuilder<AdMessage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.AdvertisementId);
            builder.Property(x => x.Message);

            builder.Property(x => x.UpdateDate).CreateDate();

            builder.Property(x => x.CreateDate).CreateDate();

            builder.HasOne(a => a.Advertisement).WithMany(a => a.Messages).HasForeignKey(a => a.AdvertisementId);

            builder.ToTable("AdMessages", "User");
        }
    }
}
