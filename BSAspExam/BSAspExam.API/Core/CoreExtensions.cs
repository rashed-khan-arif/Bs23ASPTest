using BSAspExam.Models.Identity;
using BSAspExam.Repo.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Configuration;
using System.Text;

namespace BSAspExam.API.Core
{
    public static class CoreExtensions
    {
        const string MigrationAssembly = "BSAspExam.Repo";
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Default");

                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)), (opt) =>
                 {
                     opt
                     .SchemaBehavior(MySqlSchemaBehavior.Translate, (string schemaName, string objectName) => schemaName + "_"+objectName.ToLower()).UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).EnableRetryOnFailure(5)
                     .MigrationsAssembly(MigrationAssembly);
                 });
            });

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            //services
            //    .AddScoped(typeof(IStHubRepository<>), typeof(StHubRepository<>))
            //    .AddScoped<IStudentService, StudentService>();

            return services;
        }
        public static IServiceCollection AddAppIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
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
    }
}
