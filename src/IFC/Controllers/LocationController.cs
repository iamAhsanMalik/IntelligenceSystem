namespace IFC.Controllers;

public class LocationController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public LocationController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: Locations
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.LocationRepo.GetLocationsAsync());
    }

    // GET: Locations/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var location = await _unitOfWork.LocationRepo.GetLocationsAsync(id);
        if (location == null)
        {
            return NotFound();
        }

        return View(location);
    }

    // GET: Locations/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Locations/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Latitude,Longitude,IsDeleted,IsActive")] Location location)
    {
        if (ModelState.IsValid)
        {
            _context.Add(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(location);
    }

    // GET: Locations/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Locations == null)
        {
            return NotFound();
        }

        var location = await _context.Locations.FindAsync(id);
        if (location == null)
        {
            return NotFound();
        }
        return View(location);
    }

    // POST: Locations/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Latitude,Longitude,IsDeleted,IsActive")] Location location)
    {
        if (id != location.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(location);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(location.Id))
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
        return View(location);
    }

    // GET: Locations/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Locations == null)
        {
            return NotFound();
        }

        var location = await _context.Locations
            .FirstOrDefaultAsync(m => m.Id == id);
        if (location == null)
        {
            return NotFound();
        }

        return View(location);
    }

    // POST: Locations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Locations == null)
        {
            return Problem("Entity set 'IFCDbContext.Locations'  is null.");
        }
        var location = await _context.Locations.FindAsync(id);
        if (location != null)
        {
            _context.Locations.Remove(location);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LocationExists(long id)
    {
        return _context.Locations.Any(e => e.Id == id);
    }
}
