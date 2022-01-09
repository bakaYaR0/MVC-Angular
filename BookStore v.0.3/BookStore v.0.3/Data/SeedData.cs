using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;


namespace BookStore.Data
{
    public static class SeedData
    {
        public static void InitializeDB(IServiceProvider serviceProvider)
        {
            using (var context = new BookShopContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookShopContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                var booksJson = File.ReadAllText(@"D:\Git\MVC-Angular\BookStore v.0.3\BookStore v.0.3\Data\ProgrammersLibrary.json");
                Book[] bookShelf = JsonConvert.DeserializeObject<Book[]>(booksJson);

                context.Books.AddRange(bookShelf);
                context.SaveChanges();
            }
        }
    }
}
