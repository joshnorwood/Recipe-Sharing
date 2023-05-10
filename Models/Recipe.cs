using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace Recipe_Sharing.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public string SkillLevel { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

}

