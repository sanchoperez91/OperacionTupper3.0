
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OperacionTupper3._0.Data;
using OperacionTupper3._0.Models;

public class MenusController : Controller
{
    private readonly MiDbContext _context;

    public MenusController(MiDbContext context)
    {
        _context = context;
    }

    // GET: INGREDIENTESS
    public async Task<IActionResult> Index()
    {
        var ingredientes = _context.Ingredientes
    .Include(i => i.TipoIngredienteNavigation);


        return View(await ingredientes.ToListAsync());
    }


    // GET: INGREDIENTESS/Create
    public IActionResult Create()
    {
        ViewData["Id_TipoIngrediente"] = new SelectList(_context.TipoIngrediente, "Id_TipoIngrediente", "Nombre_TipoIngrediente");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ingredientes ingredientes)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ingredientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Id_TipoIngrediente"] = new SelectList(
            _context.TipoIngrediente,
            "Id_TipoIngrediente",
            "Nombre_TipoIngrediente",
            ingredientes.Id_TipoIngrediente
        );

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

        ViewData["Id_TipoIngrediente"] = new SelectList(_context.TipoIngrediente, "Id_TipoIngrediente", "Nombre_TipoIngrediente", ingredientes.Id_TipoIngrediente);

        if (ingredientes == null)
        {

            return NotFound();

        }
        return View(ingredientes);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? Id_Ingrediente, Ingredientes ingredientes)
    {
        if (Id_Ingrediente != ingredientes.Id_Ingrediente)
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
                if (!IngredientesExists(ingredientes.Id_Ingrediente))
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
        ViewData["Id_TipoIngrediente"] = new SelectList(
                _context.TipoIngrediente,
                "Id_TipoIngrediente",
                "Nombre_TipoIngrediente",
                ingredientes.Id_TipoIngrediente
            );
        return View(ingredientes);

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
               .Include(i => i.TipoIngredienteNavigation)
            .FirstOrDefaultAsync(m => m.Id_Ingrediente == idingrediente);
        if (ingredientes == null)
        {
            return NotFound();
        }

        return View(ingredientes);
    }

    // POST: INGREDIENTESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? Id_Ingrediente)
    {
        var ingredientes = await _context.Ingredientes.FindAsync(Id_Ingrediente);
        if (ingredientes != null)
        {
            _context.Ingredientes.Remove(ingredientes);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool IngredientesExists(int? Id_Ingrediente)
    {
        return _context.Ingredientes.Any(e => e.Id_Ingrediente == Id_Ingrediente);
    }
}
