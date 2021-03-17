using FoodPal.Auth.Context;
using FoodPal.Auth.RandomStuff;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using static FoodPal.Auth.RandomStuff.CustomAuthHandlers;

namespace FoodPal.Auth
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("AuthDb")); });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityContext>();

            services.Configure<IdentityOptions>(options => 
            {
                options.Password.RequiredLength = 40;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(600);
            });

            services.AddAuthentication("CustomAuthScheme")
                .AddScheme<CustomAuthOptions, CustomAuthHandler>("CustomAuthScheme", options => { 
                    options.RandomStuffWeNeed = "Nothing"; 
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder("CustomAuthScheme")
                    .RequireAuthenticatedUser().Build();

                options.AddPolicy("AdminPolicy", builder => { builder.RequireRole("Admin"); builder.RequireAssertion(handler => env.IsDevelopment()); });
                options.AddPolicy("ClientPolicy", builder => { builder.RequireRole("Client"); });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodPal.Auth", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodPal.Auth v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ReverseProxyMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
