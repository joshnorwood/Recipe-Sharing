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

namespace Recipe_Sharing.Pages.Reviews
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Recipe_Sharing.Data.ApplicationDbContext _context;

        public IndexModel(Recipe_Sharing.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reviews != null)
            {
                Review = await _context.Reviews
                .Include(r => r.Recipe)
                .Include(r => r.User).ToListAsync();
            }
        }
    }
}
