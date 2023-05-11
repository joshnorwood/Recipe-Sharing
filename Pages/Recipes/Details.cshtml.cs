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

namespace Recipe_Sharing.Pages.Recipes
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public DetailsModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Recipe Recipe { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            else 
            {
                Recipe = recipe;
            }
            return Page();
        }
    }
}
