using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookStore_v._0._02.Models
{
    class Book
    {
        public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int AmountInStock { get; set; }
    }
}
