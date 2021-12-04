using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookStore_v._0._02.Models
{
    class Role
    {
        public int RoleID { get; set; }
        public int ProfileID { get; set; }
        public string AccessLevel { get; set; }
    }
}
