using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;

namespace Recipe_Sharing.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public DeleteModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FirstOrDefaultAsync(m => m.Id == id);

            if (review == null)
            {
                return NotFound();
            }
            else 
            {
                Review = review;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }
            var review = await _context.Reviews.FindAsync(id);

            if (review != null)
            {
                Review = review;
                _context.Reviews.Remove(Review);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
