namespace Pizzeria.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Pizzeria.Data.Models;

    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddRangeAsync(
                new Category { Name = "Pizza" },
                new Category { Name = "Drinks" },
                new Category { Name = "Burgers" },
                new Category { Name = "Salads" },
                new Category { Name = "Sauces" });
        }
    }
}
