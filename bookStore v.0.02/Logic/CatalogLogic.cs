using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookStore_v._0._02.Models;
using Newtonsoft.Json;

namespace bookStore_v._0._02.Logic
{
    public static class CatalogLogic
    {
        public static void InitializeDB()
        {
            var booksJson = File.ReadAllText(@"D:\Projects\repos\bookStore v.0.02\ProgrammersLibrary.json");
            Book[] bookShelf = JsonConvert.DeserializeObject<Book[]>(booksJson);

            using var bookShop = new BookShopContext();
            bookShop.Books.AddRange(bookShelf);
            bookShop.SaveChanges();
        }
        public static List<Book> FindBooksByField(string field)
        {
            return new List<Book>();
        }
        public static Book FindBookByID(string id)
        {
            using var bookShop = new BookShopContext();
            int intID = int.Parse(id);
            return bookShop.Books.Single(x => x.BookID == intID);
        }
        public static void CreateBook(string book)
        {
            using var bookShop = new BookShopContext();
            Book newBook = JsonConvert.DeserializeObject<Book>(book);
            bookShop.Books.Add(newBook);
            bookShop.SaveChanges();
        }
        public static bool EditBook(Book book)
        {
            return false;
        }
        public static List<Book> ShowCatalog()
        {
            using var bookShop = new BookShopContext();
            return bookShop.Books.OrderBy(x => x.BookID).ToList();
        }
        public static void DeleteBook(Book book)
        {
            using var bookShop = new BookShopContext();
            bookShop.Books.Remove(book);
            bookShop.SaveChanges();
        }
        public static bool StockUpdate(string id, int amount)
        {
            return false;
        }
    }
}
