using SluggoPIZZA.Models;
using Microsoft.EntityFrameworkCore;

namespace SluggoPIZZA.Services
{
    public class PizzaService
    {
        /* TODO: Add methods for:
        * getAllPizzas
        * createPizza
        * updatePizza(id)
        * deletePizza(id)

        Return TypedResult with PizzaDTO
         */
         static public async Task<IResult> GetAllPizzas(PizzaDB db)
        {
            return TypedResults.Ok(await db.Pizzas.Select(x => new PizzaDTO(x)).ToArrayAsync());
        }

        static public async Task<IResult> CreatePizza(PizzaDTO pizzaDTO, PizzaDB db)
        {
            // Create a new pizza with info from DTO and store it in DB
            var pizzaItem = new Pizza
            {
                Name = pizzaDTO.Name,
                Description = pizzaDTO.Description
            };
            db.Pizzas.Add(pizzaItem);
            await db.SaveChangesAsync();

            pizzaDTO = new PizzaDTO(pizzaItem);
            return TypedResults.Created($"/api/pizzas/{pizzaItem.Id}", pizzaDTO);
        }

        static public async Task<IResult> UpdatePizza(int id, PizzaDTO pizzaDTO, PizzaDB db)
        {
            var pizza = await db.Pizzas.FindAsync(id);
            if (pizza is null) return TypedResults.NotFound();

            pizza.Name = pizzaDTO.Name;
            pizza.Description = pizzaDTO.Description;

            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
        
        public static async Task<IResult> DeletePizza(int id, PizzaDB db)
        {
            var pizza = await db.Pizzas.FindAsync(id);
            if (pizza is null) return TypedResults.NotFound();

            db.Pizzas.Remove(pizza);
            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
    
}