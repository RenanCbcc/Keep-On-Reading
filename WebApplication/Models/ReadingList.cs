using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ReadingList
    {
        private List<Book> _books;

        public ReadingList(string title, params Book[] books)
        {
            Title = title;
            _books = books.ToList();
            _books.ForEach(l => l.List = this);
        }

        public string Title { get; set; }
        public IEnumerable<Book> Books
        {
            get { return _books; }
        }

        public override string ToString()
        {
            var linhas = new StringBuilder();
            linhas.AppendLine(Title);
            linhas.AppendLine("=========");
            foreach (var book in Books)
            {
                linhas.AppendLine(book.ToString());
            }
            return linhas.ToString();
        }
    }
}
