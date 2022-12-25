using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSAspExam.Repo.Configs
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.Name);

            builder.Property(x => x.UpdateDate)
                .HasDefaultValueSql("GetDate()");

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("GetDate()");

            builder.ToTable("Tags", "Ad");
        }
    }
}
