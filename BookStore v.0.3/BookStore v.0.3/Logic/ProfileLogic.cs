using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic
{
    public class ProfileLogic
    {
        private readonly BookShopContext _bookShop;
        public ProfileLogic(BookShopContext context)
        {
            _bookShop = context;
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
