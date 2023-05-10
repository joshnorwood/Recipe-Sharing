using System.Collections.Generic;
using System;

namespace Recipe_Sharing.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> Members { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
