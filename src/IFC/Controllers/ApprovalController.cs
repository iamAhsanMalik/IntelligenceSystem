namespace IFC.Controllers;

public class ApprovalController : Controller
{
    private readonly IFCDbContext _context;

    public ApprovalController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Approvals
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.Approvals.Include(a => a.ApprovalRequestType);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: Approvals/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Approvals == null)
        {
            return NotFound();
        }

        var approval = await _context.Approvals
            .Include(a => a.ApprovalRequestType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (approval == null)
        {
            return NotFound();
        }

        return View(approval);
    }

    // GET: Approvals/Create
    public IActionResult Create()
    {
        ViewData["ApprovalRequestTypeId"] = new SelectList(_context.ApprovalRequestTypes, "Id", "Id");
        return View();
    }

    // POST: Approvals/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ApprovalRequestTypeId,InitiatedOn,ApprovalStatus,IsDeleted,IsActive")] Approval approval)
    {
        if (ModelState.IsValid)
        {
            _context.Add(approval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ApprovalRequestTypeId"] = new SelectList(_context.ApprovalRequestTypes, "Id", "Id", approval.ApprovalRequestTypeId);
        return View(approval);
    }

    // GET: Approvals/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Approvals == null)
        {
            return NotFound();
        }

        var approval = await _context.Approvals.FindAsync(id);
        if (approval == null)
        {
            return NotFound();
        }
        ViewData["ApprovalRequestTypeId"] = new SelectList(_context.ApprovalRequestTypes, "Id", "Id", approval.ApprovalRequestTypeId);
        return View(approval);
    }

    // POST: Approvals/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,ApprovalRequestTypeId,InitiatedOn,ApprovalStatus,IsDeleted,IsActive")] Approval approval)
    {
        if (id != approval.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(approval);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalExists(approval.Id))
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
        ViewData["ApprovalRequestTypeId"] = new SelectList(_context.ApprovalRequestTypes, "Id", "Id", approval.ApprovalRequestTypeId);
        return View(approval);
    }

    // GET: Approvals/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Approvals == null)
        {
            return NotFound();
        }

        var approval = await _context.Approvals
            .Include(a => a.ApprovalRequestType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (approval == null)
        {
            return NotFound();
        }

        return View(approval);
    }

    // POST: Approvals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Approvals == null)
        {
            return Problem("Entity set 'IFCDbContext.Approvals'  is null.");
        }
        var approval = await _context.Approvals.FindAsync(id);
        if (approval != null)
        {
            _context.Approvals.Remove(approval);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ApprovalExists(long id)
    {
        return _context.Approvals.Any(e => e.Id == id);
    }
}
