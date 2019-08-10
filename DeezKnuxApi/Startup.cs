using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DeezKnuxApi.Data;
using JsonApiDotNetCore.Extensions;
using Microsoft.AspNetCore.Identity;
using DeezKnuxApi.Models;
using AspNet.Security.OpenIdConnect.Primitives;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using DeezKnuxApi.Repositories;
using JsonApiDotNetCore.Data;
using DeezKnuxApi.Services;
using Microsoft.AspNetCore.Http;

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

            services.AddJsonApi<AppDbcontext>();
            //opt => opt.Namespace = "api/v1"

            services.AddDbContext<AppDbcontext>(opt =>
            {
                opt.UseNpgsql(GetConnectionString());
                opt.UseOpenIddict();
            });

            // Register the Identity services.
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbcontext>()
            .AddDefaultTokenProviders();

            // Register the OpenIddict services.
            services.AddOpenIddict()
            .AddCore(options =>
            {
                // Configure OpenIddict to use the Entity Framework Core stores and entities.
                options.UseEntityFrameworkCore()
                       .UseDbContext<AppDbcontext>();
            })

            .AddServer(options =>
            {
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                options.UseMvc();

                // Enable the token endpoint (required to use the password flow).
                options.EnableAuthorizationEndpoint("/connect/authorize")
                   .EnableTokenEndpoint("/connect/token");

                // Allow client applications to use the grant_type=password flow.
                options.AllowPasswordFlow();
                options.AllowRefreshTokenFlow();

                // During development, you can disable the HTTPS requirement.
                options.DisableHttpsRequirement();

                // Accept token requests that don't specify a client_id.
                options.AcceptAnonymousClients();
            })
            .AddValidation();

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                //options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            //services.AddScoped<IHttpContextAccessor, IHttpContextAccessor>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEntityRepository<KnuxPhrase>, KnuxPhraseRepository>();

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


        public void Configure(IApplicationBuilder app,
         IHostingEnvironment env,
         ILoggerFactory loggerFactory,
         AppDbcontext context,
          UserManager<ApplicationUser> userManager
         )
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation($"Starting application in {env.EnvironmentName} environment");

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseCors(builder => {
                    builder.WithOrigins("http://localhost:4200")
                    //only use the following for dev, do not use for production
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            }

            app.UseJsonApi();

            SeedDatabase(context, userManager).Wait();
        }

        private async Task SeedDatabase(AppDbcontext context, UserManager<ApplicationUser> userManager)
        {
            if (!await context.Users.AnyAsync())
            {
                var user = new ApplicationUser {
                    UserName = "guest",
                    Email = "cameronhelkuik@gmail.com"
                };
                var result = await userManager.CreateAsync( user, "Guest1!");
                if(!result.Succeeded) throw new ApplicationException("Could not created default user");

                context.KnuxPhrases.Add(new KnuxPhrase {
                    Owner = user,
                    KnuxValue = "punk cats"
                });

                context.KnuxPhrases.Add(new KnuxPhrase {
                    KnuxValue = "funk bats"
                });

                context.SaveChanges();
            }
        }
        private string GetConnectionString()
        {
            return Configuration["ConnectionString"];
        }
    }
}
