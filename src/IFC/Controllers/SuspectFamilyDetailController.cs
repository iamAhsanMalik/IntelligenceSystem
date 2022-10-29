namespace IFC.Controllers;

public class SuspectFamilyDetailController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public SuspectFamilyDetailController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: SuspectFamilyDetails
    public async Task<IActionResult> Index()
    {
        var result = await _unitOfWork.SuspectFamilyDetailRepo.GetSuspectFamilyDetailsAsync();
        return View();
    }

    // GET: SuspectFamilyDetails/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var suspectFamilyDetail = await _unitOfWork.SuspectFamilyDetailRepo.GetSuspectFamilyDetailsAsync(id);
        if (suspectFamilyDetail == null)
        {
            return NotFound();
        }

        return View(suspectFamilyDetail);
    }

    // GET: SuspectFamilyDetails/Create
    public IActionResult Create()
    {
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id");
        return View();
    }

    // POST: SuspectFamilyDetails/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,CNIC,Passport,MaritalStatus,IsDeleted,IsActive,RelationTypeId")] SuspectFamilyDetail suspectFamilyDetail)
    {
        if (ModelState.IsValid)
        {
            _context.Add(suspectFamilyDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", suspectFamilyDetail.RelationTypeId);
        return View(suspectFamilyDetail);
    }

    // GET: SuspectFamilyDetails/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.SuspectFamilyDetails == null)
        {
            return NotFound();
        }

        var suspectFamilyDetail = await _context.SuspectFamilyDetails.FindAsync(id);
        if (suspectFamilyDetail == null)
        {
            return NotFound();
        }
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", suspectFamilyDetail.RelationTypeId);
        return View(suspectFamilyDetail);
    }

    // POST: SuspectFamilyDetails/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,DateOfBirth,CNIC,Passport,MaritalStatus,IsDeleted,IsActive,RelationTypeId")] SuspectFamilyDetail suspectFamilyDetail)
    {
        if (id != suspectFamilyDetail.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(suspectFamilyDetail);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspectFamilyDetailExists(suspectFamilyDetail.Id))
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
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", suspectFamilyDetail.RelationTypeId);
        return View(suspectFamilyDetail);
    }

    // GET: SuspectFamilyDetails/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.SuspectFamilyDetails == null)
        {
            return NotFound();
        }

        var suspectFamilyDetail = await _context.SuspectFamilyDetails
            .Include(s => s.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (suspectFamilyDetail == null)
        {
            return NotFound();
        }

        return View(suspectFamilyDetail);
    }

    // POST: SuspectFamilyDetails/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.SuspectFamilyDetails == null)
        {
            return Problem("Entity set 'IFCDbContext.SuspectFamilyDetails'  is null.");
        }
        var suspectFamilyDetail = await _context.SuspectFamilyDetails.FindAsync(id);
        if (suspectFamilyDetail != null)
        {
            _context.SuspectFamilyDetails.Remove(suspectFamilyDetail);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SuspectFamilyDetailExists(long id)
    {
        return _context.SuspectFamilyDetails.Any(e => e.Id == id);
    }
}
