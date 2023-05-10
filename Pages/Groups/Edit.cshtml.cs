using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;

namespace Recipe_Sharing.Pages.Groups
{
    public class EditModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public EditModel(Recipe_Sharing.Data.ApplicationDbContext context)
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

            var group =  await _context.Groups.FirstOrDefaultAsync(m => m.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            Group = group;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(Group.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GroupExists(int id)
        {
          return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
