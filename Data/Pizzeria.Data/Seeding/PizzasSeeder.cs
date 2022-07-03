namespace Pizzeria.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Pizzeria.Data;
    using Pizzeria.Data.Models;

    internal class PizzasSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Pizzas.Any())
            {
                return;
            }

            await dbContext.Pizzas.AddAsync(new Pizza
            {
                Name = "Margheritta",
                Size = "Family",
                Weight = 1100, Price = 10.35m,
                Ingredients = "Italian Dough, Tomato Sauce, Cheese, Tomatoes",
            });

            await dbContext.Pizzas.AddAsync(new Pizza
            {
                Name = "Cheese Master",
                Size = "Small",
                Weight = 350,
                Price = 4.35m,
                Ingredients = "Italian Dough, Tomato Sauce, Cheddar, Mozzarella, Blue Cheese, Ham",
            });

            await dbContext.Pizzas.AddAsync(new Pizza
            {
                Name = "Meat Mania",
                Size = "Medium",
                Weight = 1100,
                Price = 10.35m,
                Ingredients = "Italian Dough, Tomato Sauce, Mozzarella, Ham, Bacon, Salami, Sweet Corn",
            });
        }
    }
}
