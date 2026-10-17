using System;
using Microsoft.EntityFrameworkCore;

namespace backend.context;

public class RecipeDbContext(DbContextOptions<RecipeDbContext> options) : DbContext(options)
{
    public DbSet<backend.models.recipe> Recipes { get; set; } = null!;
}
