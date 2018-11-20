using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private IEnumerable<Book> Books { get; set; }

        public IActionResult Form()
        {
            //The framework will search in */Views/Books*/Form.cshtml
            var html = new ViewResult { ViewName = "Form" };
            return html;
        }

        //The id comes form Model Biding stage.
        public string Details(int id)
        {
            var repository = new ReadableRepository();
            var book = repository.allBooks.First(b => b.Id == id);
            return book.Details();
        }


        /// <summary>
        /// The Book comes form Model Biding stage.
        /// Quando uma requisição com a rota Livros/Incluir for solicitada, 
        /// antes de chamar o método Incluir() o estágio de Model Binding irá procurar por 
        /// informações referentes a um livro (título e autor) em três fontes: no formulário, na rota e na query string.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        private string Include(Book book)
        {
            var repository = new ReadableRepository();
            repository.Include(book);
            return string.Format("{0} has been registred successfully", book.Title);
        }

        public IActionResult ToRead()
        {
            var repository = new ReadableRepository();
            ViewBag.Books = repository.ToRead.Books;
            return View("List");
        }

        public IActionResult Reading()
        {
            var repository = new ReadableRepository();
            ViewBag.Books = repository.Reading.Books;
            return View("List");
        }

        public IActionResult Read()
        {
            var repository = new ReadableRepository();
            ViewBag.Books = repository.Read.Books;
            return View("List");
        }

    }
}
