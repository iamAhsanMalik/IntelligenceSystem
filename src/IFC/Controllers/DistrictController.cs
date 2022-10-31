namespace IFC.Controllers;

public class DistrictController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public DistrictController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: Districts
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.DistrictRepo.GetDistrictsAsync());
    }

    // GET: Districts/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var district = await _unitOfWork.DistrictRepo.GetDistrictsAsync(id);
        return (district == null) ? NotFound() : View(district);
    }

    // GET: Districts/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Districts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive")] District district)
    {
        if (ModelState.IsValid)
        {
            _context.Add(district);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(district);
    }

    // GET: Districts/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Districts == null)
        {
            return NotFound();
        }

        var district = await _context.Districts.FindAsync(id);
        if (district == null)
        {
            return NotFound();
        }
        return View(district);
    }

    // POST: Districts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive")] District district)
    {
        if (id != district.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(district);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(district.Id))
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
        return View(district);
    }

    // GET: Districts/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Districts == null)
        {
            return NotFound();
        }

        var district = await _context.Districts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (district == null)
        {
            return NotFound();
        }

        return View(district);
    }

    // POST: Districts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Districts == null)
        {
            return Problem("Entity set 'IFCDbContext.Districts'  is null.");
        }
        var district = await _context.Districts.FindAsync(id);
        if (district != null)
        {
            _context.Districts.Remove(district);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DistrictExists(long id)
    {
        return _context.Districts.Any(e => e.Id == id);
    }
}
