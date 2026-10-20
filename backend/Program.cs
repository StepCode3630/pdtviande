using backend.context;
using backend.Fakers;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.NoClobber().TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Set up DataBase connection
builder.Services.AddDbContext<RecipeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())

    using var scope = app.Services.CreateScope();
    var recipeDb = scope.ServiceProvider.GetRequiredService<RecipeDbContext>();

    // Generate 10 fakes'recipes
    if (!recipeDb.Recipes.Any())
    {
        var recipes = new RecipeFaker().Generate(10);
        await recipeDb.Recipes.AddRangeAsync(recipes);
        await recipeDb.SaveChangesAsync();
    }
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
