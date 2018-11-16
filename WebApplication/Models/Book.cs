using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ReadingList List { get; set; }

        public string Detalhes()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Detalhes do Livro");
            stringBuilder.AppendLine("=====");
            stringBuilder.AppendLine($"Título: {Title}");
            stringBuilder.AppendLine($"Autor: {Author}");
            stringBuilder.AppendLine($"Lista: {List.Title}");
            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return $"{Title} - {Author}";
        }
    }
}
