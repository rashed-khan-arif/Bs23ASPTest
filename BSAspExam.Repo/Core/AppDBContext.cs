using BSAspExam.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace BSAspExam.Repo.Core
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly, type => type.Namespace?.Contains("Configs") ?? false);
        }
    }
}
