
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperacionTupper3._0.Data;
using OperacionTupper3._0.Models;
using System.Runtime.InteropServices;

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
    public async Task<IActionResult> Details(int? idPlato)
    {
        if (idPlato == null)
        {
            return NotFound();
        }

        var platos = await _context.Platos
            .FirstOrDefaultAsync(m => m.Id_Plato == idPlato);
        if (platos == null)
        {
            return NotFound();
        }

        return View(platos);
    }

    // GET: PLATOSS/Create
    public async Task<IActionResult> Create()
    {
        var vm = new PlatosConIngredientesVM
        {
            TodosLosIngredientes = await _context.Ingredientes
                .Include(i => i.TipoIngredienteNavigation)
                .ToListAsync()
        };

        return View(vm);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PlatosConIngredientesVM vm)
    {
        ModelState.Remove("TodosLosIngredientes");
        ModelState.Remove("Plato.PlatoIngredientesNavigation");
        if (ModelState.IsValid)
        {
            _context.Add(vm.Plato);
            await _context.SaveChangesAsync();

            foreach (var idIngrediente in vm.IngredientesSeleccionados)
            {
                _context.PlatoIngredientes.Add(new PlatoIngredientes
                {
                    Id_Plato = vm.Plato.Id_Plato,
                    Id_Ingrediente = idIngrediente
                });
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        vm.TodosLosIngredientes = await _context.Ingredientes
        .Include(i => i.TipoIngredienteNavigation)
        .ToListAsync();

        return View(vm);
    }

    // GET: PLATOSS/Edit/5
    public async Task<IActionResult> Edit(int? idplato)
    {
        if (idplato == null)
        {
            return NotFound();
        }
        var vm = new PlatosConIngredientesVM();
        vm.Plato = await _context.Platos.FindAsync(idplato);
       
        if (vm.Plato == null)
        {
            return NotFound();
        }
        vm.TodosLosIngredientes = await _context.Ingredientes
            .Include(i => i.TipoIngredienteNavigation)
            .ToListAsync();

        vm.IngredientesSeleccionados = await _context.PlatoIngredientes
             .Where(pi => pi.Id_Plato == idplato)
             .Select(pi => pi.Id_Ingrediente)
             .ToListAsync();

        return View(vm);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit( PlatosConIngredientesVM vm)
    {
        if ( vm.Plato.Id_Plato==0)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vm.Plato);
                var ingredientesActuales = await _context.PlatoIngredientes
                    .Where(pi => pi.Id_Plato == vm.Plato.Id_Plato)
                    .ToListAsync();

                _context.PlatoIngredientes.RemoveRange(ingredientesActuales);

                foreach (var idingrediente in vm.IngredientesSeleccionados) {
                    _context.PlatoIngredientes.Add(new PlatoIngredientes
                    {
                        Id_Plato = vm.Plato.Id_Plato,
                        Id_Ingrediente = idingrediente
                    });
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatosExists(vm.Plato.Id_Plato))
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

        vm.TodosLosIngredientes = await _context.Ingredientes
            .Include(i => i.TipoIngredienteNavigation)
            .ToListAsync();

        return View(vm);
    }

    // GET: PLATOSS/Delete/5
    public async Task<IActionResult> Delete(int? idPlato)
    {
        if (idPlato == null)
        {
            return NotFound();
        }

        var platos = await _context.Platos
            .FirstOrDefaultAsync(m => m.Id_Plato == idPlato);
        if (platos == null)
        {
            return NotFound();
        }

        return View(platos);
    }

    // POST: PLATOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? idPlato)
    {
        var platos = await _context.Platos.FindAsync(idPlato);
        if (platos != null)
        {

            var ingredientesActuales = await _context.PlatoIngredientes
                   .Where(pi => pi.Id_Plato == idPlato)
                   .ToListAsync();

            _context.PlatoIngredientes.RemoveRange(ingredientesActuales);
            _context.Platos.Remove(platos);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PlatosExists(int? idPlato)
    {
        return _context.Platos.Any(e => e.Id_Plato == idPlato);
    }
}
