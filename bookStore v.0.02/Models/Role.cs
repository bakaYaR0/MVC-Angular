using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookStore_v._0._02.Models
{
    class Role
    {
        public enum AccessLevel
        {
            Host,
            Admin,
            Editor,
            User,
            Guest,
            Unknown
        }
    }
}
