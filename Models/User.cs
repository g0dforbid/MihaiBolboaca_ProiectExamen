using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string Password {
            get; set; }

        public ICollection<UserRoles> Roles { get; set; }

    }
}
