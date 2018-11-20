using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

            //Now, my applcaton is using the .NET's Core routing service. 
            services.AddRouting();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //Only use this in developing and testing, never deployment!
            app.UseDeveloperExceptionPage();
            // This line does the same what the commented code does.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });


        }


    }
}
