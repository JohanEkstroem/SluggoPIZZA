using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SluggoPIZZA.Models;
using SluggoPIZZA.Services;
var builder = WebApplication.CreateBuilder(args);

// Add SQLite configuration
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";
builder.Services.AddSqlite<PizzaDB>(connectionString);

// Add Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "SluggoPIZZA API", Description = "Keep track of your pizzas", Version = "v1" });
});

// Add Cors configuration (allow all)
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
  options.AddPolicy(MyAllowSpecificOrigins,
  builder =>
  {
    builder.WithOrigins("*");
  });
});
var app = builder.Build();

// Add Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "SluggoPIZZA API V1");
});

// Use the CORS capability
app.UseCors(MyAllowSpecificOrigins);

RouteGroupBuilder pizzaItems = app.MapGroup("/api/pizzas");

pizzaItems.MapGet("/", PizzaService.GetAllPizzas);
pizzaItems.MapPost("/", PizzaService.CreatePizza);
pizzaItems.MapPut("/{id}", PizzaService.UpdatePizza);
pizzaItems.MapDelete("/{id}", PizzaService.DeletePizza);
app.Run();
