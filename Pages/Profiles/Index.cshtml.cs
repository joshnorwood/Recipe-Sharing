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
    public class IndexModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public IndexModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ApplicationUser != null)
            {
                ApplicationUser = await _context.ApplicationUser.ToListAsync();
            }
        }
    }
}
