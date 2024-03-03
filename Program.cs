using Microsoft.EntityFrameworkCore;
using sprint_books.Models;


namespace sprint_books
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<sprint_books.Models.SprintContext>();
            
            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Userdetail}/{action=Register}/{id?}");

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });


    }
}

/*Code Attribute
* Source:https://youtu.be/3rAD03PFQlQ?si=ZBh2GEcJz4-9o8mE
* Creater :LearnWithMe#1 Bokhandel Webbshop|ASP.NET Core MVC Projekt
*/