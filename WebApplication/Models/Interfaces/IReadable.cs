using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public interface IReadable
    {
        ReadingList ToRead { get; }
        ReadingList Reading { get; }
        ReadingList Read { get; }
        IEnumerable<Book> Todos { get; }
        void Include(Book book);
    }
}
