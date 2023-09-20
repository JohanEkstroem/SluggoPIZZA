using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SluggoPIZZA.Models
{
    public class PizzaDB : DbContext
    {
        public PizzaDB(DbContextOptions options) : base(options) {}
        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }
}