using bookStore_v._0._02.Models;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Data.Entity;

namespace bookStore_v._0._02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bookShop = new BookShopContext())
            {
                var book = new Book() { ISBN = "9781593279509" };

                bookShop.Books.Add(book);
                bookShop.SaveChanges();
            }

            Book[] bookShelf = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(@"D:\Projects\repos\bookStore v.0.02\jsconfig1.json"));

            var titleSortedBookshelf = bookShelf.OrderBy(x => x.Title);
            var valueSortedBookshelf = bookShelf.OrderByDescending(x => x.Value);
            var authorSortedBookshelf = bookShelf.OrderBy(x => x.Author);

            var pageSortedBookshelf = bookShelf.Where(x => x.Value < 300).OrderBy(x => x.Pages);    
            var authorList = bookShelf.Select(x => x.Author).OrderBy(x => x);

            var publisher = bookShelf.GroupBy(x => x.Publisher).OrderBy(x => x.Key).ToList();
        }
    }
}
