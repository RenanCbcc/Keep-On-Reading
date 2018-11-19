using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class FakeRepository : IReadable
    {
        private ReadingList _toRead;
        private ReadingList _reading;
        private ReadingList _read;

        public FakeRepository()
        {
            var b1 = new Book { Title = "O Iluminado", Author = "Stephen King" };
            var b2 = new Book { Title = "It, a coisa", Author = "Stephen King" };
            var b3 = new Book { Title = "Carrie, a estranha", Author = "Stephen King" };
            var b4 = new Book { Title = "Sob a Redoma", Author = "Stephen King" };
            var b5 = new Book { Title = "Cemiterio Maldito", Author = "Stephen King" };
            var b6 = new Book { Title = "A Escolha dos Tres - Torre Negra 2", Author = "Stephen King" };
            var b7 = new Book { Title = "O Pistoleiro - Torre Negra 1", Author = "Stephen King" };
            var b8 = new Book { Title = "Terras Devastadas - Torre Negra 3", Author = "Stephen King" };
            var b9 = new Book { Title = "O Mago e o Vidro - Torre Negra 4", Author = "Stephen King" };
            var b10 = new Book { Title = "Lobos de Calla - Torre Negra 5", Author = "Stephen King" };
            var b11 = new Book { Title = "A Danca da Morte", Author = "Stephen King" };
            var b12 = new Book { Title = "Sombras da Noite", Author = "Stephen King" };

            _toRead = new ReadingList("Para Ler", b1, b4, b5, b12);
            _reading = new ReadingList("Lendo", b3, b11);
            _read = new ReadingList("Lidos", b2, b6, b7, b9, b8, b10);
        }

        public ReadingList ToRead(){return _toRead; }
        public ReadingList Reading() { return _reading; }
        public ReadingList Read() { return _read; }

        public IEnumerable<Book> allBooks() { throw new System.NotImplementedException(); }

        public void Include(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}
