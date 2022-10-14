using IFC.Infrastructure.Persistence;

namespace IFC.Controllers;

public class CitiesController : Controller
{
    private readonly IFCDbContext _context;

    public CitiesController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Cities
    public async Task<IActionResult> Index()
    {
        return View(await _context.Cities.ToListAsync());
    }

    // GET: Cities/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Cities == null)
        {
            return NotFound();
        }

        var city = await _context.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // GET: Cities/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Cities/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive")] City city)
    {
        if (ModelState.IsValid)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(city);
    }

    // GET: Cities/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Cities == null)
        {
            return NotFound();
        }

        var city = await _context.Cities.FindAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return View(city);
    }

    // POST: Cities/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive")] City city)
    {
        if (id != city.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.Id))
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
        return View(city);
    }

    // GET: Cities/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Cities == null)
        {
            return NotFound();
        }

        var city = await _context.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // POST: Cities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Cities == null)
        {
            return Problem("Entity set 'IFCDbContext.Cities'  is null.");
        }
        var city = await _context.Cities.FindAsync(id);
        if (city != null)
        {
            _context.Cities.Remove(city);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CityExists(long id)
    {
        return _context.Cities.Any(e => e.Id == id);
    }
}
