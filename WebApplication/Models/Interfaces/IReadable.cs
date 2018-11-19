using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public interface IReadable
    {
        ReadingList ToRead();
        ReadingList Reading();
        ReadingList Read();
        IEnumerable<Book> allBooks();
        void Include(Book book);
    }
}
