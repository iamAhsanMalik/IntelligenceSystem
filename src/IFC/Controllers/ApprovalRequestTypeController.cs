namespace IFC.Controllers;

public class ApprovalRequestTypeController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ApprovalRequestTypeController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: ApprovalRequestTypes
    public async Task<IActionResult> Index()
    {
        var result = await _unitOfWork.ApprovalRequestTypeRepo.GetApprovalRequestTypesAsync();
        return View(result);
    }

    // GET: ApprovalRequestTypes/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.ApprovalRequestTypes == null)
        {
            return NotFound();
        }

        var approvalRequestType = await _unitOfWork.ApprovalRequestTypeRepo.GetApprovalRequestTypesAsync(id);
        if (approvalRequestType == null)
        {
            return NotFound();
        }

        return View(approvalRequestType);
    }

    // GET: ApprovalRequestTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ApprovalRequestTypes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,RequestType,IsDeleted,IsActive")] ApprovalRequestType approvalRequestType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(approvalRequestType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(approvalRequestType);
    }

    // GET: ApprovalRequestTypes/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.ApprovalRequestTypes == null)
        {
            return NotFound();
        }

        var approvalRequestType = await _context.ApprovalRequestTypes.FindAsync(id);
        if (approvalRequestType == null)
        {
            return NotFound();
        }
        return View(approvalRequestType);
    }

    // POST: ApprovalRequestTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,RequestType,IsDeleted,IsActive")] ApprovalRequestType approvalRequestType)
    {
        if (id != approvalRequestType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(approvalRequestType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalRequestTypeExists(approvalRequestType.Id))
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
        return View(approvalRequestType);
    }

    // GET: ApprovalRequestTypes/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.ApprovalRequestTypes == null)
        {
            return NotFound();
        }

        var approvalRequestType = await _context.ApprovalRequestTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (approvalRequestType == null)
        {
            return NotFound();
        }

        return View(approvalRequestType);
    }

    // POST: ApprovalRequestTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.ApprovalRequestTypes == null)
        {
            return Problem("Entity set 'IFCDbContext.ApprovalRequestTypes'  is null.");
        }
        var approvalRequestType = await _context.ApprovalRequestTypes.FindAsync(id);
        if (approvalRequestType != null)
        {
            _context.ApprovalRequestTypes.Remove(approvalRequestType);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ApprovalRequestTypeExists(long id)
    {
        return _context.ApprovalRequestTypes.Any(e => e.Id == id);
    }
}
