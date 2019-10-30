using Game.DataAccess;
using Game.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ADO.NET_HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("MyConnectionString");

            using (var context = new GameContext(connectionString))
            {
                SearchService search = new SearchService(context);
                var pageNumber = 1;
                var isExit = true;
                while (isExit)
                {
                    Console.Clear();
                    search.ShowAll(pageNumber);
                    Console.WriteLine("\n'*' для выхода.");
                    Console.Write("Введите номер страницы: ");
                    var inConsole = Console.ReadLine();
                    int.TryParse(inConsole, out pageNumber);
                    if (inConsole == "*") isExit = false;
                }
            }
        }
    }
}
