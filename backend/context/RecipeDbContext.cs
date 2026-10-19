using System;
using Microsoft.EntityFrameworkCore;

namespace backend.context;

public class RecipeDbContext(DbContextOptions<RecipeDbContext> options) : DbContext(options)
{
    public DbSet<backend.models.Recipe> Recipes { get; set; } = null!;
}
