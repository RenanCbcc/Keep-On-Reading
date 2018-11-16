using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ReadableRepository: IReadable
    {
        private static readonly string nomeArquivoCSV = "Repositories\\books.csv";

        private ReadingList _toRead;
        private ReadingList _reading;
        private ReadingList _read;

        public ReadableRepository()
        {
            var arrayParaLer = new List<Book>();
            var arrayLendo = new List<Book>();
            var arrayLidos = new List<Book>();

            using (var file = File.OpenText(ReadableRepository.nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var textBook = file.ReadLine();
                    if (string.IsNullOrEmpty(textBook))
                    {
                        continue;
                    }
                    var infoBook = textBook.Split(';');
                    var book = new Book
                    {
                        Id = Convert.ToInt32(infoBook[1]),
                        Title = infoBook[2],
                        Author = infoBook[3]
                    };
                    switch (infoBook[0])
                    {
                        case "para-ler":
                            arrayParaLer.Add(book);
                            break;
                        case "lendo":
                            arrayLendo.Add(book);
                            break;
                        case "lidos":
                            arrayLidos.Add(book);
                            break;
                        default:
                            break;
                    }
                }
            }

            _toRead = new ReadingList("Para Ler", arrayParaLer.ToArray());
            _reading = new ReadingList("Lendo", arrayLendo.ToArray());
            _read = new ReadingList("Lidos", arrayLidos.ToArray());
        }

        public ReadingList ToRead => _toRead;
        public ReadingList Reading => _reading;
        public ReadingList Read => _read;

        public IEnumerable<Book> Todos => _toRead.Books.Union(_reading.Books).Union(_read.Books);

        
        public void Include(Book book)
        {
            var id = Todos.Select(l => l.Id).Max();
            using (var file = File.AppendText(ReadableRepository.nomeArquivoCSV))
            {
                file.WriteLine($"para-ler;{id + 1};{book.Title};{book.Author}");
            }

        }

        
    }
}
