using BSAspExam.Models.Identity;
using BSAspExam.Repo.Core;
using BSAspExam.Repo.Impl;
using BSAspExam.Repo.UOW;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BSAspExam.API.Core
{
    public static class CoreExtensions
    {
        const string MigrationAssembly = "BSAspExam.Repositories";
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Default");

                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)), (opt) =>
                 {
                     opt
                     .SchemaBehavior(MySqlSchemaBehavior.Translate, (string schemaName, string objectName) => schemaName + "_" + objectName.ToLower()).UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).EnableRetryOnFailure(5)
                     .MigrationsAssembly(MigrationAssembly);
                 });
            });

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>)); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddAppIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Lockout.MaxFailedAccessAttempts = 10;
            })
              .AddEntityFrameworkStores<AppDBContext>()
              .AddDefaultTokenProviders();

            services.AddScoped<JWTService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
            return services;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return user.HasClaim(a => a.Type == JwtRegisteredClaimNames.Jti)
                ? int.Parse(user.FindFirst(a => a.Type == JwtRegisteredClaimNames.Jti).Value)
                : -2;
        }
    }
}
