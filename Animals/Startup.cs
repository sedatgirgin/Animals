using Animals.Caching.Abstract;
using Animals.Caching.Concrate;
using Animals.DataAccess;
using Animals.MiddleWare;
using Animals.Repositories.Abstract;
using Animals.Repositories.Concrate;
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

namespace Animals
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AnimalsDbContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpContextAccessor();

            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<ICache, Cache>();

            services.AddMemoryCache();
            services.AddHttpClient();
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseMiddleware<ErrorHandling>();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
