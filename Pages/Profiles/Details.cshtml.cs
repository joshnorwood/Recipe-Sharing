using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;

namespace Recipe_Sharing.Pages.Profiles
{
    public class DetailsModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public DetailsModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ApplicationUser ApplicationUser { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var applicationuser = await _context.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);
            if (applicationuser == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicationUser = applicationuser;
            }
            return Page();
        }
    }
}
