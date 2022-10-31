namespace IFC.Controllers;

public class OperationalBaseController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public OperationalBaseController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: OperationalBases
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.OperationalBaseRepo.GetOperationalBaseDetailsAsync());
    }

    // GET: OperationalBases/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var operationalBase = await _unitOfWork.OperationalBaseRepo.GetOperationalBaseDetailsAsync(id);
        if (operationalBase == null)
        {
            return NotFound();
        }

        return View(operationalBase);
    }

    // GET: OperationalBases/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: OperationalBases/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive")] OperationalBase operationalBase)
    {
        if (ModelState.IsValid)
        {
            _context.Add(operationalBase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(operationalBase);
    }

    // GET: OperationalBases/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.OperationalBases == null)
        {
            return NotFound();
        }

        var operationalBase = await _context.OperationalBases.FindAsync(id);
        if (operationalBase == null)
        {
            return NotFound();
        }
        return View(operationalBase);
    }

    // POST: OperationalBases/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive")] OperationalBase operationalBase)
    {
        if (id != operationalBase.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(operationalBase);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationalBaseExists(operationalBase.Id))
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
        return View(operationalBase);
    }

    // GET: OperationalBases/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.OperationalBases == null)
        {
            return NotFound();
        }

        var operationalBase = await _context.OperationalBases
            .FirstOrDefaultAsync(m => m.Id == id);
        if (operationalBase == null)
        {
            return NotFound();
        }

        return View(operationalBase);
    }

    // POST: OperationalBases/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.OperationalBases == null)
        {
            return Problem("Entity set 'IFCDbContext.OperationalBases'  is null.");
        }
        var operationalBase = await _context.OperationalBases.FindAsync(id);
        if (operationalBase != null)
        {
            _context.OperationalBases.Remove(operationalBase);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OperationalBaseExists(long id)
    {
        return _context.OperationalBases.Any(e => e.Id == id);
    }
}
