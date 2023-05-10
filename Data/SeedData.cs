using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Recipe_Sharing.Data;
using Recipe_Sharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
           
            context.Database.Migrate();

           
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

          
            SeedRecipes(context);
            SeedGroups(context);
            SeedReviews(context);
            SeedUsers(context, userManager);

            context.SaveChanges();
        }
    }


    private static void SeedRecipes(ApplicationDbContext context)
    {
        if (context.Recipes.Any()) return;

        var recipes = new List<Recipe>
        {
            new Recipe
            {
                Title = "Classic Margherita Pizza",
                Ingredients = "Pizza dough, San Marzano tomatoes, fresh mozzarella cheese, fresh basil, salt, pepper",
                Instructions = "Preheat oven to 475°F. Place pizza dough on a floured surface and stretch out to desired shape. Spread San Marzano tomatoes over dough, leaving about 1/2 inch of space around the edges. Add fresh mozzarella cheese on top of sauce. Season with salt and pepper. Bake in oven for 10-15 minutes or until crust is golden brown. Remove from oven and sprinkle fresh basil leaves over pizza. Slice and serve.",
                PrepTime = "30 minutes",
                CookTime = "15 minutes",
                SkillLevel = "Intermediate",
                UserId = "1"
            },
            new Recipe
            {
                Title = "Lemon Garlic Butter Salmon",
                Ingredients = "Salmon fillet, butter, garlic, lemon, salt, pepper",
                Instructions = "Preheat oven to 375°F. Melt butter in a small saucepan over low heat. Add minced garlic and stir for 1-2 minutes. Add the juice of half a lemon and continue stirring for another 1-2 minutes. Place salmon fillet on a baking sheet lined with parchment paper. Season with salt and pepper. Brush lemon garlic butter mixture over salmon. Bake in oven for 15-20 minutes or until salmon is cooked through. Remove from oven and serve.",
                PrepTime = "10 minutes",
                CookTime = "20 minutes",
                SkillLevel = "Beginner",
                UserId = "2"
            },
            new Recipe
            {
                Title = "Chicken Alfredo Pasta",
                Ingredients = "Fettuccine pasta, chicken breast, heavy cream, parmesan cheese, garlic, salt, pepper",
                Instructions = "Cook fettuccine pasta according to package directions. While pasta is cooking, season chicken breast with salt and pepper. Heat oil in a pan over medium-high heat. Add chicken and cook until no longer pink. Remove chicken from pan and set aside. In the same pan, add minced garlic and cook for 1-2 minutes. Add heavy cream and parmesan cheese. Stir until cheese is melted and sauce is heated through. Add cooked fettuccine to pan and toss in sauce. Serve with sliced chicken on top.",
                PrepTime = "15 minutes",
                CookTime = "25 minutes",
                SkillLevel = "Intermediate",
                UserId = "3"
            },
            new Recipe
            {
                Title = "Grilled Cheese Sandwich",
                Ingredients = "Bread, cheddar cheese, butter",
                Instructions = "Heat a pan over medium heat. Butter one side of each slice of bread. Place one slice of bread butter side down in the pan. Add cheddar cheese on top of bread. Place second slice of bread on top, and continue cooking until the cheese is melted and the bread is golden brown, about 2-3 minutes per side. Remove from the pan and serve hot.",
                PrepTime = "5 minutes",
                CookTime = "5 minutes",
                SkillLevel = "Beginner",
                UserId = "4"
            },
            new Recipe
            {
                Title = "Spaghetti and Meatballs",
                Ingredients = "Spaghetti, ground beef, bread crumbs, parmesan cheese, egg, milk, garlic, salt, pepper, tomato sauce",
                Instructions = "Cook spaghetti according to package directions. While spaghetti is cooking, mix together ground beef, bread crumbs, parmesan cheese, egg, milk, minced garlic, salt, and pepper in a bowl. Roll mixture into 2-inch meatballs. Heat oil in a pan over medium-high heat. Add meatballs and cook until browned on all sides. Pour tomato sauce over meatballs and bring to a simmer. Cover and cook for 10-15 minutes, until meatballs are cooked through. Serve meatballs and sauce over cooked spaghetti.",
                PrepTime = "20 minutes",
                CookTime = "25 minutes",
                SkillLevel = "Intermediate",
                UserId = "5"
            }
        };

        context.Recipes.AddRange(recipes);
        context.SaveChanges();
    }

    private static void SeedGroups(ApplicationDbContext context)
    {
        if (context.Groups.Any()) return;

        var groups = new List<Group>
    {
        new Group
        {
            Name = "Vegetarian Recipes",
            Description = "A group for sharing and discovering vegetarian recipes.",
            Members = new List<ApplicationUser>(),
            Recipes = new List<Recipe>()
        },
        new Group
        {
            Name = "Gluten-Free Recipes",
            Description = "A group for sharing and discovering gluten-free recipes.",
            Members = new List<ApplicationUser>(),
            Recipes = new List<Recipe>()
        },
        new Group
        {
            Name = "International Cuisine",
            Description = "A group for sharing and discovering recipes from around the world.",
            Members = new List<ApplicationUser>(),
            Recipes = new List<Recipe>()
        },
        new Group
        {
            Name = "Healthy Eating",
            Description = "A group for sharing and discovering healthy recipes.",
            Members = new List<ApplicationUser>(),
            Recipes = new List<Recipe>()
        },
        new Group
        {
            Name = "Desserts and Sweets",
            Description = "A group for sharing and discovering dessert and sweet recipes.",
            Members = new List<ApplicationUser>(),
            Recipes = new List<Recipe>()
        }
    };

        context.Groups.AddRange(groups);
        context.SaveChanges();
    }

    private static void SeedReviews(ApplicationDbContext context)
    {
        if (context.Reviews.Any()) return;

        var reviews = new List<Review>
    {
        new Review
        {
            Comment = "This pizza was amazing!",
            Rating = 5,
            UserId = "1",
            RecipeId = 1
        },
        new Review
        {
            Comment = "The lemon garlic butter sauce was delicious.",
            Rating = 4,
            UserId = "2",
            RecipeId = 2
        },
        new Review
        {
            Comment = "The chicken alfredo pasta was creamy and flavorful.",
            Rating = 4,
            UserId = "3",
            RecipeId = 3
        },
        new Review
        {
            Comment = "The grilled cheese sandwich was crispy and cheesy.",
            Rating = 3,
            UserId = "4",
            RecipeId = 4
        },
        new Review
        {
            Comment = "The meatballs were juicy and flavorful.",
            Rating = 4,
            UserId = "5",
            RecipeId = 5,

        }
        };
        context.Reviews.AddRange(reviews);
        context.SaveChanges();
    }


    private static async Task SeedUsers(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        if (context.Users.Any()) return;

        var users = new List<ApplicationUser>
    {
        new ApplicationUser
        {
            UserName = "user1@example.com",
            Email = "user1@example.com",
        },
        new ApplicationUser
        {
            UserName = "user2@example.com",
            Email = "user2@example.com",
        },
        new ApplicationUser
        {
            UserName = "user3@example.com",
            Email = "user3@example.com",
        },
        new ApplicationUser
        {
            UserName = "user4@example.com",
            Email = "user4@example.com",
        },
        new ApplicationUser
        {
            UserName = "user5@example.com",
            Email = "user5@example.com",
        }
    };

        foreach (var user in users)
        {
            var password = "Password1!";
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(user, "Member");

                if (!roleResult.Succeeded)
                {
                    throw new Exception("Failed to add user to role");
                }
            }
            else
            {
                throw new Exception("Failed to create user");
            }
        }
    }
}
