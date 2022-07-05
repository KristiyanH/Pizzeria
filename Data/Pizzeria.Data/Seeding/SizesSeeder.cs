namespace Pizzeria.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Pizzeria.Data.Models;

    internal class SizesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sizes.Any())
            {
                return;
            }

            await dbContext.Sizes.AddRangeAsync(
                new Size { Name = "Small" },
                new Size { Name = "Medium" },
                new Size { Name = "Large" },
                new Size { Name = "XXL" },
                new Size { Name = "Family" });
        }
    }
}
