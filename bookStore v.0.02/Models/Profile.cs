using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookStore_v._0._02.Models
{
    class Profile
    {
        public string ProfileID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public Role UserRole { get; set; }

    }
}
