using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Controllers;

namespace WebApplication
{
    public class Startup
    {
        private BooksController booksController;
        public void ConfigureServices(IServiceCollection services)
        {
            booksController = new BooksController();

            //Now, my applcaton is using the .NET's Core routing service. 
            services.AddRouting();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            // This line does the same what the commented code does.
            app.UseMvcWithDefaultRoute();
            /*var builder = new RouteBuilder(app);
            builder.MapRoute("Books/ToRead", booksController.ToRead);
            builder.MapRoute("Books/Reading", booksController.Reading);
            builder.MapRoute("Books/Read", booksController.Read);
            builder.MapRoute("Books/Details/{id:int}", booksController.Details);
            builder.MapRoute("/Books/Include/", booksController.Include);
            builder.MapRoute("Books/Form/", booksController.Form);
            var routes = builder.Build();
            app.UseRouter(routes);
            */
        }


    }
}
