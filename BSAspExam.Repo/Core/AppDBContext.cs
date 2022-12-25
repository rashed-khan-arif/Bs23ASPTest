using BSAspExam.Models.Common;
using BSAspExam.Models.Domain;
using BSAspExam.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace BSAspExam.Repo.Core
{ 
    public class AppDBContext : IdentityDbContext<ApplicationUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly, type => type.Namespace?.Contains("Configs") ?? false);
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<AdLocation> AdLocations { get; set; }
        public virtual DbSet<AdContactInfo> AdContactInfos { get; set; }
        public virtual DbSet<AdImage> AdImages { get; set; }
        public virtual DbSet<AdMessage> AdMessages { get; set; }
        public virtual DbSet<AdTag> AdTags { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }
        public virtual DbSet<ProductCategory> ProductCategorys { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserBlacklist> UserBlacklists { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
    }
}
