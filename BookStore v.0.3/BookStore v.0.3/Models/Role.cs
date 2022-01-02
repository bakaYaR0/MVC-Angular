using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public int ProfileID { get; set; }
        public string AccessLevel { get; set; }
    }
}
