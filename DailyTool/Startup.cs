using DTValueObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DailyTool
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connection = @"Server=.;Database=PlanDaily;Trusted_Connection=True;User Id=sa;Password=123456;";
            services.AddDbContext<PlanDailyContext>(options => options.UseSqlServer(connection));
            //

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "mysite.com",
                    ValidAudience="mysite.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Anhzxcjjqiuvqinqmjahduuduuduudullllllllllllllllllfllflflff"))
            };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Admin", "1"));
                options.AddPolicy("Employee", policy => policy.RequireClaim("Employee", "2"));
                options.AddPolicy("Manager", policy => policy.RequireClaim("Manager", "3"));
                options.AddPolicy("AE", policy => policy.RequireRole("Admin", "Employee"));
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Admin","1"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Customer", policy => policy.RequireClaim("Customer","3"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Tester", policy => policy.RequireClaim("Tester","4"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Manager", policy => policy.RequireClaim("Manager","2"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PlanDailyContext>();
                context.Database.EnsureCreated();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
