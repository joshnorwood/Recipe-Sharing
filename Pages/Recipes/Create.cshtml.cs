using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;

namespace Recipe_Sharing.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public CreateModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Recipes == null || Recipe == null)
            {
                return Page();
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
