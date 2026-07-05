
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperacionTupper3._0.Models;
using OperacionTupper3._0.Data;

public class PlatosController : Controller
{
    private readonly MiDbContext _context;

    public PlatosController(MiDbContext context)
    {
        _context = context;
    }

    // GET: PLATOSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Platos.ToListAsync());
    }

    // GET: PLATOSS/Details/5
    public async Task<IActionResult> Details(int? idplato)
    {
        if (idplato == null)
        {
            return NotFound();
        }

        var platos = await _context.Platos
            .FirstOrDefaultAsync(m => m.IdPlato == idplato);
        if (platos == null)
        {
            return NotFound();
        }

        return View(platos);
    }

    // GET: PLATOSS/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdPlato,NombrePlato,Descripcion,PlatoIngredientesNavigation")] Platos platos)
    {
        if (ModelState.IsValid)
        {
            _context.Add(platos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(platos);
    }

    // GET: PLATOSS/Edit/5
    public async Task<IActionResult> Edit(int? idplato)
    {
        if (idplato == null)
        {
            return NotFound();
        }

        var platos = await _context.Platos.FindAsync(idplato);
        if (platos == null)
        {
            return NotFound();
        }
        return View(platos);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? idplato, [Bind("IdPlato,NombrePlato,Descripcion,PlatoIngredientesNavigation")] Platos platos)
    {
        if (idplato != platos.IdPlato)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(platos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatosExists(platos.IdPlato))
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
        return View(platos);
    }

    // GET: PLATOSS/Delete/5
    public async Task<IActionResult> Delete(int? idplato)
    {
        if (idplato == null)
        {
            return NotFound();
        }

        var platos = await _context.Platos
            .FirstOrDefaultAsync(m => m.IdPlato == idplato);
        if (platos == null)
        {
            return NotFound();
        }

        return View(platos);
    }

    // POST: PLATOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? idplato)
    {
        var platos = await _context.Platos.FindAsync(idplato);
        if (platos != null)
        {
            _context.Platos.Remove(platos);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PlatosExists(int? idplato)
    {
        return _context.Platos.Any(e => e.IdPlato == idplato);
    }
}
