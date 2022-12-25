using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Repositories.Core
{
    internal static class Extensions
    {
        public static PropertyBuilder<DateTime> CreateDate(this PropertyBuilder<DateTime> builder)
        {
            builder.HasColumnType("TIMESTAMP").HasDefaultValueSql("(UTC_TIMESTAMP())");
            return builder;
        }
    }
}
