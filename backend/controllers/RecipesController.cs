using backend.context;
using backend.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeDbContext _context;

        public RecipesController(RecipeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            return recipe is null ? NotFound() : Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
                return BadRequest();

            if (!await _context.Recipes.AnyAsync(r => r.Id == id))
                return NotFound();

            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe is null)
                return NotFound();

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
