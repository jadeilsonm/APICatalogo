using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ApiCatalogoDbContext _context;

    public CategoryController(ApiCatalogoDbContext context)
    {
        _context = context;
    }

    // GET: api/Category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        // take limite de resultado para melhoria no desempenho para as cosultas do banco de dados.
        return await _context.Categories.Take(10).AsNoTracking().ToListAsync(); // evitar sobrecarga devido ao rastreio para cache do framework
    }
    
    // GET: api/Category/products
    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAndPRoducts()
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }

        return await _context.Categories.Include(p => p.Products).ToListAsync();
    }

    // GET: api/Category/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }

        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return category;
    }

    // PUT: api/Category/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (id != category.CategoryId)
        {
            return BadRequest();
        }

        _context.Entry(category).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Category
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        if (_context.Categories == null)
        {
            return Problem("Entity set 'ApiCatalogoDbContext.Categories'  is null.");
        }

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
    }

    // DELETE: api/Category/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    

    private bool CategoryExists(int id)
    {
        return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
    }
}


