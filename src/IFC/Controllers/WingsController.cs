using IFC.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IFC.Controllers;

public class WingsController : Controller
{
    private readonly IFCDbContext _context;

    public WingsController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Wings
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.Wings.Include(w => w.CoreHeadQuarter);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: Wings/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Wings == null)
        {
            return NotFound();
        }

        var wing = await _context.Wings
            .Include(w => w.CoreHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (wing == null)
        {
            return NotFound();
        }

        return View(wing);
    }

    // GET: Wings/Create
    public IActionResult Create()
    {
        ViewData["CoreHeadQuarterId"] = new SelectList(_context.CoreHeadQuarters, "Id", "Id");
        return View();
    }

    // POST: Wings/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,IsSacaapplied,Sacatype,WingType,DisplayName,IsActive,IsDeleted,CoreHeadQuarterId")] Wing wing)
    {
        if (ModelState.IsValid)
        {
            _context.Add(wing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CoreHeadQuarterId"] = new SelectList(_context.CoreHeadQuarters, "Id", "Id", wing.CoreHeadQuarterId);
        return View(wing);
    }

    // GET: Wings/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Wings == null)
        {
            return NotFound();
        }

        var wing = await _context.Wings.FindAsync(id);
        if (wing == null)
        {
            return NotFound();
        }
        ViewData["CoreHeadQuarterId"] = new SelectList(_context.CoreHeadQuarters, "Id", "Id", wing.CoreHeadQuarterId);
        return View(wing);
    }

    // POST: Wings/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,IsSacaapplied,Sacatype,WingType,DisplayName,IsActive,IsDeleted,CoreHeadQuarterId")] Wing wing)
    {
        if (id != wing.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(wing);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WingExists(wing.Id))
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
        ViewData["CoreHeadQuarterId"] = new SelectList(_context.CoreHeadQuarters, "Id", "Id", wing.CoreHeadQuarterId);
        return View(wing);
    }

    // GET: Wings/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Wings == null)
        {
            return NotFound();
        }

        var wing = await _context.Wings
            .Include(w => w.CoreHeadQuarter)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (wing == null)
        {
            return NotFound();
        }

        return View(wing);
    }

    // POST: Wings/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Wings == null)
        {
            return Problem("Entity set 'IFCDbContext.Wings'  is null.");
        }
        var wing = await _context.Wings.FindAsync(id);
        if (wing != null)
        {
            _context.Wings.Remove(wing);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WingExists(long id)
    {
        return _context.Wings.Any(e => e.Id == id);
    }
}
