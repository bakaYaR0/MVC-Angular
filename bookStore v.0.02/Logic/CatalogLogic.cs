using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookStore_v._0._02.Models;

namespace bookStore_v._0._02.Logic
{
    class CatalogLogic
    {
        public List<Book> FindBooksByField(string field)
        {
            return new List<Book>();
        }
        public Book FindBookByISBN(string isbn)
        {
            return new Book();
        }
        public bool CreateBook(Book book)
        {
            return false;
        }
        public bool EditBook(Book book)
        {
            return false;
        }
        public List<Book> ShowCatalog()
        {
            return new List<Book>();
        }
        public bool DeleteBook(Book book)
        {
            return false;
        }
        public bool StockUpdate(string id, int amount)
        {
            return false;
        }
    }
}
