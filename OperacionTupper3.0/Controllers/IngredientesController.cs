
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperacionTupper3._0.Models;
using OperacionTupper3._0.Data;

public class IngredientesController : Controller
{
    private readonly MiDbContext _context;

    public IngredientesController(MiDbContext context)
    {
        _context = context;
    }

    // GET: INGREDIENTESS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Ingredientes.ToListAsync());
    }

    // GET: INGREDIENTESS/Details/5
    public async Task<IActionResult> Details(int? idingrediente)
    {
        if (idingrediente == null)
        {
            return NotFound();
        }

        var ingredientes = await _context.Ingredientes
            .FirstOrDefaultAsync(m => m.IdIngrediente == idingrediente);
        if (ingredientes == null)
        {
            return NotFound();
        }

        return View(ingredientes);
    }

    // GET: INGREDIENTESS/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdIngrediente,NombreIngrediente,TipoIngrediente,PlatoIngredientesNavigation")] Ingredientes ingredientes)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ingredientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ingredientes);
    }

    // GET: INGREDIENTESS/Edit/5
    public async Task<IActionResult> Edit(int? idingrediente)
    {
        if (idingrediente == null)
        {
            return NotFound();
        }

        var ingredientes = await _context.Ingredientes.FindAsync(idingrediente);
        if (ingredientes == null)
        {
            return NotFound();
        }
        return View(ingredientes);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? idingrediente, [Bind("IdIngrediente,NombreIngrediente,TipoIngrediente,PlatoIngredientesNavigation")] Ingredientes ingredientes)
    {
        if (idingrediente != ingredientes.IdIngrediente)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ingredientes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientesExists(ingredientes.IdIngrediente))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(ingredientes);
    }

    // GET: INGREDIENTESS/Delete/5
    public async Task<IActionResult> Delete(int? idingrediente)
    {
        if (idingrediente == null)
        {
            return NotFound();
        }

        var ingredientes = await _context.Ingredientes
            .FirstOrDefaultAsync(m => m.IdIngrediente == idingrediente);
        if (ingredientes == null)
        {
            return NotFound();
        }

        return View(ingredientes);
    }

    // POST: INGREDIENTESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? idingrediente)
    {
        var ingredientes = await _context.Ingredientes.FindAsync(idingrediente);
        if (ingredientes != null)
        {
            _context.Ingredientes.Remove(ingredientes);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool IngredientesExists(int? idingrediente)
    {
        return _context.Ingredientes.Any(e => e.IdIngrediente == idingrediente);
    }
}
