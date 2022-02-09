using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Book>> ShowCatalog()
        {
            return await _bookShop.Books.OrderBy(x => x.BookID).ToListAsync();
        }

        public async Task<Book> FindBookByID(int id)
        {
            try
            {
                return await _bookShop.Books.SingleAsync(x => x.BookID == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: FindBookByID(" + id + ")" + "\n" + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        public async Task<List<Book>> FindBooksByField(string field)
        {
            try
            {
                return await _bookShop.Books.Where(x => x.Author.Contains(field) ||
                                                x.ISBN.Contains(field) ||
                                                x.Title.Contains(field) ||
                                                x.Description.Contains(field)).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: FindBooksByField(" + field + ")" + "\n" + e.Message + "\n" + e.StackTrace);
                return new List<Book>();
            }
        }

        public void CreateBook(Book book)
        {
            try
            {
                _bookShop.Books.Add(book);
                _bookShop.SaveChanges();
                Console.WriteLine("Addition Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("The Book was not created" + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        public async Task<bool> EditBook(Book book)
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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteBook(Book book)
        {
            try
            {
                var bookToDelete = _bookShop.Books.Single(x => x.BookID == book.BookID);
                _bookShop.Books.Remove(bookToDelete);
                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Deletion successful");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                return false;
            }
        }

        public async void StockUpdate(int id, int amount)
        {
            try
            {
                var bookToUpdate = _bookShop.Books.Single(x => x.BookID == id);
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
