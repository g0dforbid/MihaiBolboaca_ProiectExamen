using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;
        public List<SelectListItem> Roles { get; set; }

        public CreateModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // get all roles
             var roles = this._context.Role
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = Convert.ToString(x.ID)
                }).ToList();
            this.Roles = roles;

            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string[] RoleIds = Request.Form["roles"].ToString().Split(",");

            _context.User.Add(User);
            var UserRolesVar = _context.User.First();
            UserRolesVar.Roles = new List<UserRoles>();
            foreach (string ID in RoleIds)
            {
                UserRolesVar.Roles.Add(new UserRoles
                {
                    RoleID = _context.Role.Where(r => r.ID == Convert.ToInt32(ID))
                    .First().ID
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
