using BookStore.Data;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic
{
    public  class OrderLogic
    {
        private readonly BookShopContext _bookShop;
        public OrderLogic(BookShopContext context)
        {
            _bookShop = context;
        }

        public void MakeOrder(string order)
        {
            try
            {
                Order newOrder = JsonConvert.DeserializeObject<Order>(order);
                _bookShop.Orders.Add(newOrder);
                _bookShop.SaveChanges();
                Console.WriteLine("Addition Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("The Book was not created" + "\n" + e.Message + "\n" + e.StackTrace);
            }

        }

        public async void EditOrder(Order order)
        {
            try
            {
                var orderToEdit = _bookShop.Orders.Single(x => x.OrderID == order.OrderID);
                
                
                if (order == null || orderToEdit == null)
                    throw new Exception("Source or/and Destination Objects are null");
                if (orderToEdit.Status != "Complete")
                {
                    orderToEdit.Address = order.Address;
                    orderToEdit.DeliveryType = order.DeliveryType;
                    orderToEdit.PhoneNumber = order.PhoneNumber;
                    orderToEdit.Status = order.Status;
                    if (orderToEdit.Status != "Processed")
                    {
                        orderToEdit.OrderItems = order.OrderItems;
                        orderToEdit.OrderValue = order.OrderValue;
                    }
                }

                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Edit Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        public async void ChangeOrderStatus(Order order)
        {
            try
            {
                var orderToEdit = _bookShop.Orders.Single(x => x.OrderID == order.OrderID);

                if (order == null || orderToEdit == null)
                    throw new Exception("Source or/and Destination Objects are null");
                if (orderToEdit.Status != "Complete")
                {
                    orderToEdit.Status = order.Status;
                }

                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Update Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
