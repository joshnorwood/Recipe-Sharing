using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Recipe_Sharing.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DietaryPreferences { get; set; }
        public string DietaryRestrictions { get; set; }
        public string SkillLevel { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }

}

