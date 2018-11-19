using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Now, my applcaton is using the .NET's Core routing service. 
             services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Books/ToRead",BooksToRead);
            builder.MapRoute("Books/Reading",BooksReading);
            builder.MapRoute("Books/Read",BooksRead);
            builder.MapRoute("Books/Details/{id:int}", BooksDetails);
            builder.MapRoute("Registre/NewBook/{title}/{author}",NewBookToRead);
            var routes = builder.Build();
            app.UseRouter(routes);
           
        }

        private Task BooksDetails(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repository = new ReadableRepository();
            var book = repository.allBooks().First(b => b.Id == id);
            return context.Response.WriteAsync(book.Details());
        }
        private Task NewBookToRead(HttpContext context)
        {
            var book = new Book(context.GetRouteValue("title").ToString(), context.GetRouteValue("author").ToString());
            var repository = new ReadableRepository();
            repository.Include(book);
            return context.Response.WriteAsync(string.Format("{0} has been registred successfully", book.Title));
        }

        public Task BooksToRead(HttpContext context)
        {
            var repository = new ReadableRepository();
            return context.Response.WriteAsync(repository.ToRead().ToString());
        }

        public Task BooksReading(HttpContext context)
        {
            var repository = new ReadableRepository();
            return context.Response.WriteAsync(repository.Reading().ToString());
        }
        public Task BooksRead(HttpContext context)
        {
            var repository = new ReadableRepository();
            return context.Response.WriteAsync(repository.Read().ToString());
        }
    }
}
