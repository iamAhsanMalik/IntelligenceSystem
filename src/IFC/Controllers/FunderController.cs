namespace IFC.Controllers;

public class FunderController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public FunderController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: Funders
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.FunderRepo.GetFundersAsync());
    }

    // GET: Funders/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var funder = await _unitOfWork.FunderRepo.GetFundersAsync(id);
        if (funder == null)
        {
            return NotFound();
        }

        return View(funder);
    }

    // GET: Funders/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Funders/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,FundingSource,IsDeleted,IsActive")] Funder funder)
    {
        if (ModelState.IsValid)
        {
            _context.Add(funder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(funder);
    }

    // GET: Funders/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Funders == null)
        {
            return NotFound();
        }

        var funder = await _context.Funders.FindAsync(id);
        if (funder == null)
        {
            return NotFound();
        }
        return View(funder);
    }

    // POST: Funders/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,FundingSource,IsDeleted,IsActive")] Funder funder)
    {
        if (id != funder.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(funder);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunderExists(funder.Id))
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
        return View(funder);
    }

    // GET: Funders/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Funders == null)
        {
            return NotFound();
        }

        var funder = await _context.Funders
            .FirstOrDefaultAsync(m => m.Id == id);
        if (funder == null)
        {
            return NotFound();
        }

        return View(funder);
    }

    // POST: Funders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Funders == null)
        {
            return Problem("Entity set 'IFCDbContext.Funders'  is null.");
        }
        var funder = await _context.Funders.FindAsync(id);
        if (funder != null)
        {
            _context.Funders.Remove(funder);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FunderExists(long id)
    {
        return _context.Funders.Any(e => e.Id == id);
    }
}
