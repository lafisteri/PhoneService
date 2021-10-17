using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhonesBusinessLayer;
using PhonesBusinessLayer.MapperProfile;
using PhonesDataLayer;

namespace PhonePresentationLayer
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
            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(PhoneProfile))
            };
            services.AddAutoMapper(assemblies);

            services.AddDbContext<Context>();
            services.AddScoped<IPhonesService, PhonesService>();
            services.AddScoped<IPhonesRepository, PhonesRepository>();

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
