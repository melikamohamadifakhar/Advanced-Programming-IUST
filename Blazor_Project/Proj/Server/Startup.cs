using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P8.Server.DB;
using System.Linq;

namespace P8.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* CORS */
            services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            /* CORS */
            services.AddControllersWithViews();
            services.AddRazorPages();
            string sqlConnectionString = "Host=ec2-54-158-232-223.compute-1.amazonaws.com;Port=5432;Database=deoj2a5crf8egp;Username=zwhezdwwmgrqcg;Password=4aa63ec7b6deddea703febe68c05cc4eac2ce9eb33438a82a01823fdf5964d2c;sslmode=Prefer;Trust Server Certificate=true;";
            services.AddDbContext<ClotheDbContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddScoped<ClotheProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
