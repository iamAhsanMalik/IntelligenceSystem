using IFC.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IFC.Controllers;

public class CoreHeadQuartersController : Controller
{
    private readonly IFCDbContext _context;

    public CoreHeadQuartersController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: CoreHeadQuarters
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.CoreHeadQuarters.Include(c => c.SectorHeadQuarter);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: CoreHeadQuarters/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.CoreHeadQuarters == null)
        {
            return NotFound();
        }

        var coreHeadQuarter = await _context.CoreHeadQuarters
            .Include(c => c.SectorHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (coreHeadQuarter == null)
        {
            return NotFound();
        }

        return View(coreHeadQuarter);
    }

    // GET: CoreHeadQuarters/Create
    public IActionResult Create()
    {
        ViewData["SectorHeadQuarterId"] = new SelectList(_context.SectorHeadQuarters, "Id", "Id");
        return View();
    }

    // POST: CoreHeadQuarters/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,DisplayName,SectorHeadQuarterId,IsDeleted")] CoreHeadQuarter coreHeadQuarter)
    {
        if (ModelState.IsValid)
        {
            _context.Add(coreHeadQuarter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["SectorHeadQuarterId"] = new SelectList(_context.SectorHeadQuarters, "Id", "Id", coreHeadQuarter.SectorHeadQuarterId);
        return View(coreHeadQuarter);
    }

    // GET: CoreHeadQuarters/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.CoreHeadQuarters == null)
        {
            return NotFound();
        }

        var coreHeadQuarter = await _context.CoreHeadQuarters.FindAsync(id);
        if (coreHeadQuarter == null)
        {
            return NotFound();
        }
        ViewData["SectorHeadQuarterId"] = new SelectList(_context.SectorHeadQuarters, "Id", "Id", coreHeadQuarter.SectorHeadQuarterId);
        return View(coreHeadQuarter);
    }

    // POST: CoreHeadQuarters/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,IsActive,DisplayName,SectorHeadQuarterId,IsDeleted")] CoreHeadQuarter coreHeadQuarter)
    {
        if (id != coreHeadQuarter.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(coreHeadQuarter);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoreHeadQuarterExists(coreHeadQuarter.Id))
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
        ViewData["SectorHeadQuarterId"] = new SelectList(_context.SectorHeadQuarters, "Id", "Id", coreHeadQuarter.SectorHeadQuarterId);
        return View(coreHeadQuarter);
    }

    // GET: CoreHeadQuarters/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.CoreHeadQuarters == null)
        {
            return NotFound();
        }

        var coreHeadQuarter = await _context.CoreHeadQuarters
            .Include(c => c.SectorHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (coreHeadQuarter == null)
        {
            return NotFound();
        }

        return View(coreHeadQuarter);
    }

    // POST: CoreHeadQuarters/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.CoreHeadQuarters == null)
        {
            return Problem("Entity set 'IFCDbContext.CoreHeadQuarters'  is null.");
        }
        var coreHeadQuarter = await _context.CoreHeadQuarters.FindAsync(id);
        if (coreHeadQuarter != null)
        {
            _context.CoreHeadQuarters.Remove(coreHeadQuarter);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CoreHeadQuarterExists(long id)
    {
        return _context.CoreHeadQuarters.Any(e => e.Id == id);
    }
}
