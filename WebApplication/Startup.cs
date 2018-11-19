using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //Takes a method thar returns a Task object.
            app.Run(Routing);
        }

        public Task Routing(HttpContext context) {
            
            var suportedPaths = new Dictionary<string, RequestDelegate>
            {
                { "/Books/ToRead",BooksToRead},
                { "/Books/Reading",BooksReading},
                { "/Books/Read",BooksRead}
            };

            if (suportedPaths.ContainsKey(context.Request.Path))
            {
                //It receives a method of request delegate type.
                var method = suportedPaths[context.Request.Path];
                return method.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("https://http.cat/404");
            }
            
        }


        public Task BooksToRead(HttpContext context)
        {
            var _repo = new FakeRepository();
            return context.Response.WriteAsync(_repo.ToRead().ToString());
        }

        public Task BooksReading(HttpContext context)
        {
            var _repo = new FakeRepository();
            return context.Response.WriteAsync(_repo.Reading().ToString());
        }
        public Task BooksRead(HttpContext context)
        {
            var _repo = new FakeRepository();
            return context.Response.WriteAsync(_repo.Read().ToString());
        }
    }
}
