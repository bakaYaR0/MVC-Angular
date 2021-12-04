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
        public class BookShopContext : DbContext
        {
            public BookShopContext()
                : base("DbConnection")
            { }

            public DbSet<Address> Addresses { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Profile> Profiles { get; set; }
            public DbSet<Role> Roles { get; set; }
        }


        static void Main(string[] args)
        {
            using (BookShopContext db = new BookShopContext())
            {
                // создаем два объекта User
                Book user1 = new Book { ISBN = "Tom", BookID = 33 };
                Book user2 = new Book { ISBN = "Sam", BookID = 26 };

                // добавляем их в бд
                db.Books.Add(user1);
                db.Books.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var books = db.Books;
                Console.WriteLine("Список объектов:");
                foreach (Book u in books)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.BookID, u.ISBN);
                }
            }
            Console.Read();


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
