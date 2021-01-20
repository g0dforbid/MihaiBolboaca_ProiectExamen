using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;
        public string DisplayRoleNames;

        public DetailsModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User
                .Include(u => u.Roles)
                .ThenInclude(userRoles => userRoles.Role)
                .FirstOrDefaultAsync(m => m.ID == id);

            string roleNames = "";
            foreach(UserRoles ur in User.Roles)
            {
                roleNames += ur.Role.Name + ", ";
            }

            this.DisplayRoleNames = roleNames;

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
