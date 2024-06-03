using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABMProveedores.Data;
using ABMProveedores.Models;
using System.Threading.Tasks;

public class ProveedoresController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProveedoresController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Proveedores.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Proveedor proveedor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(proveedor);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null)
        {
            return NotFound();
        }
        return View(proveedor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Proveedor proveedor)
    {
        if (id != proveedor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(proveedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(proveedor.Id))
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
        return View(proveedor);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proveedor = await _context.Proveedores
            .FirstOrDefaultAsync(m => m.Id == id);
        if (proveedor == null)
        {
            return NotFound();
        }

        return View(proveedor);
    }

    // ProveedoresController.cs

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null)
        {
            return NotFound();
        }

        _context.Proveedores.Remove(proveedor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    private bool ProveedorExists(int id)
    {
        return _context.Proveedores.Any(e => e.Id == id);
    }
}

