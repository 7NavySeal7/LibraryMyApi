using Infraestructure.Core.Data;
using LibraryApiR.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApiR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Context SQl Server
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("ConnectionStringSQLServer"),
                                            providerOptions => providerOptions.EnableRetryOnFailure());
            });
            #endregion

            #region Semilla de datos
            services.AddTransient<SeedDb>();
            #endregion

            #region Inyeccion de dependecias
            DependencyInyectionHandler.DependencyInyectionConfig(services);
            #endregion

            #region Swagger 1/2

            SwaggerHandler.SwaggerConfig(services);

            #endregion Swagger 1/2

            #region Jwt Token Configuration 1/2

            //Configuration proviene de la inyección de Iconfiguration del constructor
            IConfigurationSection tokenAppSetting = Configuration.GetSection("Tokens");
            JwtConfigurationHandler.ConfigureJwtAuthentication(services, tokenAppSetting);

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Swagger 2/2

            SwaggerHandler.UseSwagger(app);

            #endregion 2/2

            #region Jwt Token Configuration 2/2

            JwtConfigurationHandler.ConfigureUseAuthentication(app);

            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
