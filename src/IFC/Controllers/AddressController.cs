namespace IFC.Controllers;

public class AddressController : Controller
{
    private readonly IFCDbContext _context;

    public AddressController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Address
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.Addresses.Include(a => a.City).Include(a => a.District);
        var result = await iFCDbContext.ToListAsync();
        return View(result);
    }

    // GET: Address/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Addresses == null)
        {
            return NotFound();
        }

        var address = await _context.Addresses
            .Include(a => a.City)
            .Include(a => a.District)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (address == null)
        {
            return NotFound();
        }

        return View(address);
    }

    // GET: Address/Create
    public IActionResult Create()
    {
        ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
        ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id");
        return View();
    }

    // POST: Address/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Streat,IsDeleted,IsActive,CityId,DistrictId")] Address address)
    {
        if (ModelState.IsValid)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", address.CityId);
        ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", address.DistrictId);
        return View(address);
    }

    // GET: Address/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Addresses == null)
        {
            return NotFound();
        }

        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", address.CityId);
        ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Name", address.DistrictId);
        return View(address);
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Streat,IsDeleted,IsActive,CityId,DistrictId")] Address address)
    {
        if (id != address.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(address);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address.Id))
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
        ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", address.CityId);
        ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", address.DistrictId);
        return View(address);
    }

    // GET: Address/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Addresses == null)
        {
            return NotFound();
        }

        var address = await _context.Addresses
            .Include(a => a.City)
            .Include(a => a.District)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (address == null)
        {
            return NotFound();
        }

        return View(address);
    }

    // POST: Address/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Addresses == null)
        {
            return Problem("Entity set 'IFCDbContext.Addresses'  is null.");
        }
        var address = await _context.Addresses.FindAsync(id);
        if (address != null)
        {
            _context.Addresses.Remove(address);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AddressExists(long id)
    {
        return _context.Addresses.Any(e => e.Id == id);
    }
}
