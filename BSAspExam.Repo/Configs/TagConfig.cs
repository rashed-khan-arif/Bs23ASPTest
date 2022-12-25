using BSAspExam.Models.Domain;
using BSAspExam.Repositories.Core;
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

            builder.Property(x => x.UpdateDate).CreateDate();

            builder.Property(x => x.CreateDate).CreateDate();

            builder.ToTable("Tags", "Ad");
        }
    }
}
