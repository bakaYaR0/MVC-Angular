using bookStore_v._0._02.Models;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace bookStore_v._0._02
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] bookShelf = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(@"C:\Users\fpaaf\source\repos\bookStore v.0.02\jsconfig1.json"));

            var titleSortedBookshelf = bookShelf.OrderBy(x => x.Title);
            var valueSortedBookshelf = bookShelf.OrderByDescending(x => x.Value);
            var authorSortedBookshelf = bookShelf.OrderBy(x => x.Author);

            var pageSortedBookshelf = bookShelf.Where(x => x.Value < 300).OrderBy(x => x.Pages);
            var authorList = bookShelf.Select(x => x.Author).OrderBy(x => x);


            foreach (var book in bookShelf)
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}Rub\n", book.Title, book.Author, book.ISBN, book.Pages, book.Value);
            Console.WriteLine("---------------------------------------------------------");
            foreach (var book in titleSortedBookshelf)
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}Rub\n", book.Title, book.Author, book.ISBN, book.Pages, book.Value);
            Console.WriteLine("---------------------------------------------------------");
            foreach (var book in valueSortedBookshelf)
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}Rub\n", book.Title, book.Author, book.ISBN, book.Pages, book.Value);
            Console.WriteLine("---------------------------------------------------------");
            foreach (var book in authorSortedBookshelf)
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}Rub\n", book.Title, book.Author, book.ISBN, book.Pages, book.Value);
            Console.WriteLine("---------------------------------------------------------");
            foreach (var book in pageSortedBookshelf)
                Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}Rub\n", book.Title, book.Author, book.ISBN, book.Pages, book.Value);
            Console.WriteLine("---------------------------------------------------------");
            foreach (var author in authorList)
                Console.WriteLine(author + "\n");
        }
    }
}
