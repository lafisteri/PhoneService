using System.Reflection;
using BusinessLayer.MapperProfile;
using BusinessLayer.Services.AuthService;
using BusinessLayer.Services.HashService;
using BusinessLayer.Services.PhonesService;
using BusinessLayer.Services.UserService;
using Core.Models;
using DataLayer;
using DataLayer.PhonesRepository;
using DataLayer.UserRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace PresentationLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthOptions>(Configuration.GetSection(nameof(AuthOptions)));
            var authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey
                            (System.Text.Encoding.ASCII.GetBytes(authOptions.SecretKey)),
                        ValidateIssuerSigningKey = true
                    };
                });

            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(PhoneProfile))
            };
            services.AddAutoMapper(assemblies);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPhonesService, PhonesService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashService, HashService>();

            services.AddDbContext<Context>();
            services.AddScoped<IPhonesRepository, PhonesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
