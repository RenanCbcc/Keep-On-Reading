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
            var l1 = new Book { Title = "O Iluminado", Author = "Stephen King" };
            var l2 = new Book { Title = "It, a coisa", Author = "Stephen King" };
            var l3 = new Book { Title = "Carrie, a estranha", Author = "Stephen King" };
            var l4 = new Book { Title = "Sob a Redoma", Author = "Stephen King" };
            var l5 = new Book { Title = "Cemiterio Maldito", Author = "Stephen King" };
            var l6 = new Book { Title = "A Escolha dos Tres - Torre Negra 2", Author = "Stephen King" };
            var l7 = new Book { Title = "O Pistoleiro - Torre Negra 1", Author = "Stephen King" };
            var l8 = new Book { Title = "Terras Devastadas - Torre Negra 3", Author = "Stephen King" };
            var l9 = new Book { Title = "O Mago e o Vidro - Torre Negra 4", Author = "Stephen King" };
            var l10 = new Book { Title = "Lobos de Calla - Torre Negra 5", Author = "Stephen King" };
            var l11 = new Book { Title = "A Danca da Morte", Author = "Stephen King" };
            var l12 = new Book { Title = "Sombras da Noite", Author = "Stephen King" };

            _toRead = new ReadingList("Para Ler", l1, l4, l5, l12);
            _reading = new ReadingList("Lendo", l3, l11);
            _read = new ReadingList("Lidos", l2, l6, l7, l9, l8, l10);
        }

        public ReadingList ToRead => _toRead;
        public ReadingList Reading => _reading;
        public ReadingList Read => _read;

        public IEnumerable<Book> Todos => throw new System.NotImplementedException();

        public void Include(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}
