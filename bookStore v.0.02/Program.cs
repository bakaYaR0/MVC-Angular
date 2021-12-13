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

            var newBook = @"{
                            'author': 'Chinua Achebe',
                            'country': 'Nigeria',
                            'imageLink': 'images/things-fall-apart.jpg',
                            'language': 'English',
                            'link': 'https://en.wikipedia.org/wiki/Things_Fall_Apart\n',
                            'pages': 209,
                            'title': 'Things Fall Apart',
                            'year': 1958
                          }";

            CatalogLogic.CreateBook(newBook);
            var bookFound = CatalogLogic.FindBookByID("58");
            Console.WriteLine(bookFound.Author + "\n" + bookFound.Title + "\n" + bookFound.Pages + "\n" + bookFound.Value + "\n");
            CatalogLogic.DeleteBook(bookFound);


            var bookChoices = CatalogLogic.FindBooksByField("au");
            foreach (var book in bookChoices)
                Console.WriteLine(book.Author + "\n" + book.Title + "\n" + book.Pages + "\n" + book.Value + "\n");

            CatalogLogic.StockUpdate("3", 6);
        }
    }
}
