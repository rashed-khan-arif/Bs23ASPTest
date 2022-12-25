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
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.Verified);
            builder.Property(x => x.Slug);

            builder.Property(x => x.UpdateDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("GetDate()");

            builder.HasOne(a => a.AdContactInfo).WithOne(a => a.Advertisement).HasForeignKey<AdContactInfo>(a => a.AdvertisementId);
            builder.HasOne(a => a.Location).WithMany(a => a.Advertisements).HasForeignKey(a => a.LocationId);
            builder.HasOne(a => a.CreatedByUser).WithMany(a => a.Advertisements).HasForeignKey(a => a.CreatedBy);
          
            builder.ToTable("Advertisements", "Ad");
        }
    }
}
