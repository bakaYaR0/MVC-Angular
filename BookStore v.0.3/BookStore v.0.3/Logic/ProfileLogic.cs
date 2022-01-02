using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic
{
    internal class ProfileLogic
    {
        public BookShopContext bookShop;
        public ProfileLogic()
        {
            bookShop = new BookShopContext();
        }

        public Profile CreateProfile()
        {
            return new Profile();
        }

        public void ShowProfileInfo()
        {

        }

        public void EditProfile()
        {

        }

        public void DeleteProfile()
        {

        }
    }
}
