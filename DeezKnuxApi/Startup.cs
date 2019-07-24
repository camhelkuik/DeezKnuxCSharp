using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DeezKnuxApi.Data;
using JsonApiDotNetCore.Extensions;

namespace DeezKnuxApi
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            services.AddDbContext<AppDbcontext>(opt => opt.UseNpgsql(GetConnectionString()));
            services.AddJsonApi<AppDbcontext>();
            //opt => opt.Namespace = "api/v1"
        }

        // // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        // {
        //     if (env.IsDevelopment())
        //     {
        //         app.UseDeveloperExceptionPage();
        //     }
        //     else
        //     {
        //         app.UseHsts();
        //     }

        //     app.UseHttpsRedirection();
        //    // app.UseMvc();
        //    app.UseJsonApi();
        // }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            }
           app.UseJsonApi();
        }

        private string GetConnectionString()
        {
            return Configuration["ConnectionString"];
        }
    }
}
