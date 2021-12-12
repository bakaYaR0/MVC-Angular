using bookStore_v._0._02.Models;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Data.Entity;
using bookStore_v._0._02.Logic;

namespace bookStore_v._0._02
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookshelf = CatalogLogic.ShowCatalog();

            foreach (var book in bookshelf)
                Console.WriteLine(book.Author + "\n" + book.Title + "\n" + book.Pages + "\n" + book.Value + "\n");
        }
    }
}
