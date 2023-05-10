using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipe_Sharing.Models;

namespace Recipe_Sharing.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Recipe_Sharing.Models.ApplicationUser> ApplicationUser { get; set; } = default!;
}

