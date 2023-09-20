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
    }
    
}