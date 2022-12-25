﻿using BSAspExam.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repo.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.CategoryId);
            builder.Property(x => x.BrandId);
            builder.Property(x => x.Description);
            builder.Property(x => x.Active); 
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.ToTable("Products", "Prod");
        }
    }
}
