using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.Cookies;
using sem_2_k_2.Services;

namespace sem_2_k_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IProductService, InMemoryProductService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/Account/Login");
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Serve index.html when the application starts
            var homeUiPath = Path.Combine(app.Environment.ContentRootPath, "Views", "Home");
            if (Directory.Exists(homeUiPath))
            {
                app.UseDefaultFiles(new DefaultFilesOptions
                {
                    FileProvider = new PhysicalFileProvider(homeUiPath),
                    RequestPath = ""
                });
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(homeUiPath),
                    RequestPath = ""
                });
            }
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
