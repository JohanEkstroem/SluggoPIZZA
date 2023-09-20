using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SluggoPIZZA.Models
{
    public class PizzaDTO
    {
        /* To prevent over-posting, best practice is to use a DTO. 
        In this case a DTO is implemented but not actually needed */
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public PizzaDTO() { }
        public PizzaDTO(Pizza pizza) =>
        (Id, Name, Description) = (pizza.Id, pizza.Name, pizza.Description);
    }
}
