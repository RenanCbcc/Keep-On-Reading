using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            //var _repo = new ReadableRepository();

            //ImprimeLista(_repo.ToRead);
            //ImprimeLista(_repo.Reading);
            //ImprimeLista(_repo.Read);
            
        }
        static void ImprimeLista(ReadingList lista)
        {
            Console.WriteLine(lista);
        }

       
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
