namespace IFC.Controllers;

public class SectorHeadQuarterController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public SectorHeadQuarterController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: SectorHeadQuarters
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.SectorHeadQuarterRepo.GetSectorHeadQuarterDetailsAsync());
    }

    // GET: SectorHeadQuarters/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var sectorHeadQuarter = await _unitOfWork.SectorHeadQuarterRepo.GetSectorHeadQuarterDetailsAsync(id);
        if (sectorHeadQuarter == null)
        {
            return NotFound();
        }

        return View(sectorHeadQuarter);
    }

    // GET: SectorHeadQuarters/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SectorHeadQuarters/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,IsDeleted")] SectorHeadQuarter sectorHeadQuarter)
    {
        if (ModelState.IsValid)
        {
            _context.Add(sectorHeadQuarter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sectorHeadQuarter);
    }

    // GET: SectorHeadQuarters/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.SectorHeadQuarters == null)
        {
            return NotFound();
        }

        var sectorHeadQuarter = await _context.SectorHeadQuarters.FindAsync(id);
        if (sectorHeadQuarter == null)
        {
            return NotFound();
        }
        return View(sectorHeadQuarter);
    }

    // POST: SectorHeadQuarters/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,IsActive,IsDeleted")] SectorHeadQuarter sectorHeadQuarter)
    {
        if (id != sectorHeadQuarter.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(sectorHeadQuarter);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorHeadQuarterExists(sectorHeadQuarter.Id))
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
        return View(sectorHeadQuarter);
    }

    // GET: SectorHeadQuarters/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.SectorHeadQuarters == null)
        {
            return NotFound();
        }

        var sectorHeadQuarter = await _context.SectorHeadQuarters
            .FirstOrDefaultAsync(m => m.Id == id);
        if (sectorHeadQuarter == null)
        {
            return NotFound();
        }

        return View(sectorHeadQuarter);
    }

    // POST: SectorHeadQuarters/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.SectorHeadQuarters == null)
        {
            return Problem("Entity set 'IFCDbContext.SectorHeadQuarters'  is null.");
        }
        var sectorHeadQuarter = await _context.SectorHeadQuarters.FindAsync(id);
        if (sectorHeadQuarter != null)
        {
            _context.SectorHeadQuarters.Remove(sectorHeadQuarter);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SectorHeadQuarterExists(long id)
    {
        return _context.SectorHeadQuarters.Any(e => e.Id == id);
    }
}
