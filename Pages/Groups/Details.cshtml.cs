using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Recipe_Sharing.Pages.Groups
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public DetailsModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Group Group { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var group = await _context.Groups.FirstOrDefaultAsync(m => m.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            else 
            {
                Group = group;
            }
            return Page();
        }
    }
}
