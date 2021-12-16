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
            var book = CatalogLogic.FindBookByID("60");
            book.Author = "No way this works";
            book.ISBN = "5";
            book.Title = "Dreams of The Dying";
            book.Pages = 458;
            book.Value = 643;

            CatalogLogic.EditBook(book);

        }
    }
}
