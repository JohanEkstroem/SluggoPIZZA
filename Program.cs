using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "SluggoPIZZA API", Description = "Keep track of your pizzas", Version = "v1" });
});
var app = builder.Build();

// Add Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "SluggoPIZZA API V1");
});

app.MapGet("/", () => "Hello World!");

app.Run();
