using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Newtonsoft.Json;

namespace BookStore.Logic
{
    public class CatalogLogic
    {
        private readonly BookShopContext _bookShop;
        public CatalogLogic(BookShopContext context)
        {
            _bookShop = context;
        }

        public List<Book> FindBooksByField(string field)
        {
            try
            {
                return _bookShop.Books.Where(x => x.Author.Contains(field) ||
                                                x.ISBN.Contains(field) ||
                                                x.Title.Contains(field) ||
                                                x.Description.Contains(field)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: FindBooksByField(" + field + ")" + "\n" + e.Message + "\n" + e.StackTrace);
                return new List<Book>();
            }
        }

        public Book FindBookByID(string id)
        {
            try
            {
                int intID = int.Parse(id);
                return _bookShop.Books.Single(x => x.BookID == intID);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: FindBookByID(" + id + ")" + "\n" + e.Message + "\n" + e.StackTrace);
                return new Book();
            }
        }

        public void CreateBook(string book)
        {
            try
            {
                Book newBook = JsonConvert.DeserializeObject<Book>(book);
                _bookShop.Books.Add(newBook);
                _bookShop.SaveChanges();
                Console.WriteLine("Addition Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("The Book was not created" + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        public async void EditBook(Book book)
        {
            try
            {
                var bookToEdit = _bookShop.Books.Single(x => x.BookID == book.BookID);
                if (book == null || bookToEdit == null)
                    throw new Exception("Source or/and Destination Objects are null");

                bookToEdit.ISBN = book.ISBN;
                bookToEdit.Title = book.Title;
                bookToEdit.Subtitle = book.Subtitle;
                bookToEdit.Author = book.Author;
                bookToEdit.Publisher = book.Publisher;
                bookToEdit.Pages = book.Pages;
                bookToEdit.Description = book.Description;

                bookToEdit.AmountInStock = book.AmountInStock;
                bookToEdit.Value = book.Value;

                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Edit Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        public List<Book> ShowCatalog()
        {
            return _bookShop.Books.OrderBy(x => x.BookID).ToList();
        }

        public async void DeleteBook(Book book)
        {
            try
            {
                var bookToDelete = _bookShop.Books.Single(x => x.BookID == book.BookID);
                _bookShop.Books.Remove(bookToDelete);
                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Deletion successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        public async void StockUpdate(string id, int amount)
        {
            int intID = int.Parse(id);
            try
            {
                var bookToUpdate = _bookShop.Books.Single(x => x.BookID == intID);
                bookToUpdate.AmountInStock = amount;
                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Update successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
