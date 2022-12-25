﻿using BSAspExam.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repo.Configs
{
    public class AdLocationConfig : IEntityTypeConfiguration<AdLocation>
    {
        public void Configure(EntityTypeBuilder<AdLocation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.Name);
            builder.Property(x => x.Address);
            builder.Property(x => x.ParentId).IsRequired(false);
            builder.Property(x => x.Type);
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.ToTable("AdLocations", "Ad");
        }
    }
}