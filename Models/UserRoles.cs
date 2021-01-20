using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UserRoles
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
