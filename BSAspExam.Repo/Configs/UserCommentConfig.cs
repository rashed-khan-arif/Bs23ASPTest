using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSAspExam.Repositories.Core;

namespace BSAspExam.Repositories.Configs
{
    public class UserCommentConfig : IEntityTypeConfiguration<UserComment>
    {
        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.AdvertisementId);
            builder.Property(x => x.Comments);
            builder.Property(x => x.ParentId).IsRequired(false);

            builder.Property(x => x.UpdateDate).CreateDate();

            builder.Property(x => x.CreateDate).CreateDate();

            builder.HasOne(a => a.Parent).WithMany(a => a.Childs).HasForeignKey(a => a.ParentId);


            builder.ToTable("UserComments", "User");
        }
    }
}
