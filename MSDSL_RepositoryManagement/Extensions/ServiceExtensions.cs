using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MSDSL_BLL;
using MSDSL_BLL.BLLContract;
using MSDSL_BLL.BLLRepository;
using MSDSL_DbAccessor;
using MSDSL_DbAccessor.IRepository;
using MSDSL_DbAccessor.Repository;
using MSDSL_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) //calling repositories
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<IClientBLL, ClientBLL>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IDeveloperBLL, DeveloperBLL>();
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();

            services.AddTransient<IRepositoriesRepository, RepositoriesRepository>();
            services.AddTransient<IRepositoryBLL, RepositoryBLL>();

            services.AddTransient<IRepoClientBLL, RepoClientBLL>();
            services.AddTransient<IRepoClientRepository, RepoClientRepository>(); 
            
            services.AddTransient<IRepoDevBLL, RepoDevBLL>();
            services.AddTransient<IRepoDevRepository, RepoDevRepository>();

        }
        public static void ConfigureMSSQLContext(this IServiceCollection services, IConfiguration config)//for passing database credentials
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connectionString));
        } 
        public static void ConfigureJWTBearer(this IServiceCollection services, IConfiguration Configuration)//for jwt token
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
        }
        public static void ConfigureAutoMapper(this IServiceCollection services) //tagging automapper profile
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
        public static void ConfigureSwagger(this IServiceCollection services) //Configure SwaggerGen
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MSDSL_REPO", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                    "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                    "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
