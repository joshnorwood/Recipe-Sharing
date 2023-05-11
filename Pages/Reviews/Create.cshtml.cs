using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Recipe_Sharing.Pages.Reviews
{
    [Authorize]
    public class CreateModel : PageModel
    {
        
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public CreateModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reviews == null || Review == null)
            {
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
