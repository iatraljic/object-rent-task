using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using backTStask.Models;
using Microsoft.AspNetCore.HttpsPolicy;
using Newtonsoft.Json;


namespace backTStask
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HomeOwnerContext>
                (opt => opt.UseSqlServer(Configuration["Data:backTStaskConnection:ConnectionString"]));
            services.AddControllers();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

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
