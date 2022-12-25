using BSAspExam.Models.Domain;
using BSAspExam.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repo.Configs
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Url); 
            builder.Property(x => x.Active);

            builder.Property(x => x.UpdateDate).CreateDate();

            builder.Property(x => x.CreateDate).CreateDate();

            builder.HasOne(a => a.CreatedByUser).WithMany(a => a.Images).HasForeignKey(a => a.CreatedBy);


            builder.ToTable("Images", "dbo");
        }
    }
}
