using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Recipe_Sharing.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Recipe> Recipes { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<Review> Reviews { get; set; }

        public void OnGet()
        {
            Recipes = _context.Recipes.ToList();
            Groups = _context.Groups.ToList();
            Reviews = _context.Reviews.ToList();
        }
    }
}
