using Microsoft.EntityFrameworkCore;
using sprint_books.Models;
using System.Configuration;

namespace sprint_books
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
            services.AddControllersWithViews();
            services.AddDbContext<SprintContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(name: "SprintContext")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(sp => Cart.GetCart(sp));


            services.AddDistributedMemoryCache();

            services.AddSession(options=>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential=true;
                //options.IdleTimeout = TimeSpan.FromSeconds(value:10);
            });

        }


    }
}

/*Code Attribute
* Source:https://youtu.be/j8XoyxeZgP8?si=LUrve5S1tyovpIZM
* Creater :LearnWithMe #2 Bokhandel Webbshop| Cart +Checkout|ASP.NET core MVC Projekt
*/