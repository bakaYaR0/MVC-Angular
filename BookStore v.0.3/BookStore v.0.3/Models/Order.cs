﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Book> OrderItems { get; set; }
        public string Status { get; set; } //TODO: add constant list
        public Profile OrderOwner { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal OrderValue { get; set; }
        public string DeliveryType { get; set; } //TODO: add to constant list
    }
}
