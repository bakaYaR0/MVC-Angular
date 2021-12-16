using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            using var bookShop = new BookShopContext();
            try
            {
                return bookShop.Books.Where(x => x.Author.Contains(field) ||
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

        public static Book FindBookByID(string id)
        {
            using var bookShop = new BookShopContext();
            try
            {
                int intID = int.Parse(id);
                return bookShop.Books.Single(x => x.BookID == intID);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: FindBookByID(" + id + ")" + "\n" + e.Message + "\n" + e.StackTrace);
                return new Book(); //what do we need to return ? 
            }
        }

        public static void CreateBook(string book)
        {
            using var bookShop = new BookShopContext();
            try
            {
                Book newBook = JsonConvert.DeserializeObject<Book>(book);
                bookShop.Books.Add(newBook);
                bookShop.SaveChanges();
                Console.WriteLine("Addition Successful");
            }
            catch(Exception e)
            {
                Console.WriteLine("The Book was not created" + "\n" + e.Message + "\n" + e.StackTrace);
            }
            
        }

        public static void EditBook(Book book)
        {
            using var bookShop = new BookShopContext();
            try
            {
                var bookToEdit = bookShop.Books.Single(x => x.BookID == book.BookID);
                if (book == null || bookToEdit == null)
                    throw new Exception("Source or/and Destination Objects are null");

                Type typeSource = book.GetType();
                Type typeDestintation = bookToEdit.GetType();

                PropertyInfo[] srcProps = typeSource.GetProperties();
                foreach (PropertyInfo srcProp in srcProps)
                {
                    if (!srcProp.CanRead)
                    {
                        continue;
                    }
                    PropertyInfo targetProperty = typeDestintation.GetProperty(srcProp.Name);
                    if (targetProperty == null)
                    {
                        continue;
                    }
                    if (!targetProperty.CanWrite)
                    {
                        continue;
                    }
                    if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                    {
                        continue;
                    }
                    if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                    {
                        continue;
                    }
                    if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                    {
                        continue;
                    }
                    // Passed all tests, lets set the value
                    targetProperty.SetValue(bookToEdit, srcProp.GetValue(book, null), null);
                }
                bookShop.SaveChanges();
                Console.WriteLine("Edit Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }      
        }

        public static List<Book> ShowCatalog()
        {
            using var bookShop = new BookShopContext();
            return bookShop.Books.OrderBy(x => x.BookID).ToList();
        }

        public static void DeleteBook(Book book)
        {
            using var bookShop = new BookShopContext();
            try
            {
                var bookToDelete = bookShop.Books.Single(x => x.BookID == book.BookID);
                bookShop.Books.Remove(bookToDelete);
                bookShop.SaveChanges();
                Console.WriteLine("Deletion successful");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        public static void StockUpdate(string id, int amount)
        {
            int intID = int.Parse(id);
            using var bookShop = new BookShopContext();
            try
            {
                var bookToUpdate = bookShop.Books.Single(x => x.BookID == intID);
                bookToUpdate.AmountInStock = amount;
                bookShop.SaveChanges();
                Console.WriteLine("Update successful");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
