using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;

namespace Recipe_Sharing.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public DeleteModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }
            var group = await _context.Groups.FindAsync(id);

            if (group != null)
            {
                Group = group;
                _context.Groups.Remove(Group);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
