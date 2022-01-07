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
    public class ProfileLogic
    {
        private readonly BookShopContext _bookShop;
        public ProfileLogic(BookShopContext context)
        {
            _bookShop = context;
        }

        public void CreateProfile(string profile)
        {
            try
            {
                Profile newProfile = JsonConvert.DeserializeObject<Profile>(profile);
                _bookShop.Profiles.Add(newProfile);
                _bookShop.SaveChanges();
                Console.WriteLine("Addition Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("The Profile was not created" + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        public async void EditProfile(Profile profile)
        {
            try
            {
                var profileToEdit = _bookShop.Profiles.Single(x => x.ProfileID == profile.ProfileID);
                if (profile == null || profileToEdit == null)
                    throw new Exception("Source or/and Destination Objects are null");

                profileToEdit.Login = profile.Login;
                profileToEdit.Email = profile.Email;
                profileToEdit.Birthdate = profile.Birthdate;
                profileToEdit.Password = profile.Password;
                profileToEdit.PhoneNumber = profile.PhoneNumber;
                profileToEdit.UserRole = profile.UserRole;

                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Edit Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

        }

        public async void DeleteProfile(Profile profile)
        {
            try
            {
                var profileToDelete = _bookShop.Profiles.Single(x => x.ProfileID == profile.ProfileID);
                _bookShop.Profiles.Remove(profileToDelete);
                await _bookShop.SaveChangesAsync();
                Console.WriteLine("Deletion successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
