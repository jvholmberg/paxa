using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using AutoMapper;

namespace Paxa
{
    public class Startup
    {

        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Get connection-string from config
            var connectionString = _configuration.GetConnectionString("DatabaseConnection");

            // Create connection to postgress
            services.AddDbContext<Contexts.PaxaContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddCors();
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

            // configure strongly typed settings object
            services.Configure<Helpers.AppSettings>(_configuration.GetSection("AppSettings"));

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfig().CreateConfigutation();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Services
            services.AddScoped<Authorization.IJwtUtils, Authorization.JwtUtils>();
            services.AddScoped<Services.IUserService, Services.UserService>();
            services.AddScoped<Services.IPersonService, Services.PersonService>();
            services.AddScoped<Services.IOrganizationService,Services.OrganizationService>();
            services.AddScoped<Services.IResourceService, Services.ResourceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            // Global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // Global error handler
            app.UseMiddleware<Helpers.ErrorHandlerMiddleware>();

            // Custom jwt auth middleware
            app.UseMiddleware<Authorization.JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
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
