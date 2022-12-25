using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BSAspExam.Repositories.Configs
{
    public class UserBlackListConfig : IEntityTypeConfiguration<UserBlacklist>
    {
        public void Configure(EntityTypeBuilder<UserBlacklist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Blocked);
            builder.Property(x => x.AdvertisementId);
            builder.Property(x => x.UserId);


            builder.HasOne(a => a.Advertisement).WithMany(a => a.UserBlacklists).HasForeignKey(a => a.AdvertisementId);
            builder.HasOne(a => a.User).WithMany(a => a.UserBlacklists).HasForeignKey(a => a.UserId);


            builder.ToTable("UserBlacklists", "User");
        }
    }
}
