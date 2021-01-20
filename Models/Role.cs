using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<UserRoles> Users { get; set; }
    }
}
