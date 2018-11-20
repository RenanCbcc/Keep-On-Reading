using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BooksController
    {
        public Task Form(HttpContext context)
        {
            var html = LoadHTMLFile("/Books/Form");
            return context.Response.WriteAsync(html);
        }

        private string LoadHTMLFile(string name)
        {
            var path = $"Views{name}.html";
            using (var file = File.OpenText(path))
            {
                return file.ReadToEnd();
            }
        }

        public Task Details(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repository = new ReadableRepository();
            var book = repository.allBooks.First(b => b.Id == id);
            return context.Response.WriteAsync(book.Details());
        }

        public Task Include(HttpContext context)
        {
            var book = new Book(context.Request.Form["title"].First(), context.Request.Form["author"].First());
            var repository = new ReadableRepository();
            repository.Include(book);
            return context.Response.WriteAsync(string.Format("{0} has been registred successfully", book.Title));
        }

        public Task ToRead(HttpContext context)
        {
            var repository = new ReadableRepository();
            return context.Response.WriteAsync(repository.ToRead.ToString());
        }

        public Task Reading(HttpContext context)
        {
            var repository = new ReadableRepository();
            return context.Response.WriteAsync(repository.Reading.ToString());
        }
        public Task Read(HttpContext context)
        {
            var repository = new ReadableRepository();
            var html = LoadHTMLFile("/Books/List");
            foreach (var book in repository.ToRead.Books)
            {
                html = html.Replace("#Line#", $"<li>{book.Title} - {book.Author}</li>#Line#");
            }
            html = html.Replace("#Line#", "");
            return context.Response.WriteAsync(html);
        }

        public string Test() {
            return "This is a test";
        }
    }
}
