namespace IFC.Controllers;

public class TerroristFamilyController : Controller
{
    private readonly IFCDbContext _context;

    public TerroristFamilyController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: TerroristFamilyDetails
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.TerroristFamilyDetails.Include(t => t.Address).Include(t => t.RelationType);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: TerroristFamilyDetails/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.TerroristFamilyDetails == null)
        {
            return NotFound();
        }

        var terroristFamilyDetail = await _context.TerroristFamilyDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristFamilyDetail == null)
        {
            return NotFound();
        }

        return View(terroristFamilyDetail);
    }

    // GET: TerroristFamilyDetails/Create
    public IActionResult Create()
    {
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id");
        return View();
    }

    // POST: TerroristFamilyDetails/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,IsDeleted,IsActive,AddressId,RelationTypeId")] TerroristFamilyDetail terroristFamilyDetail)
    {
        if (ModelState.IsValid)
        {
            _context.Add(terroristFamilyDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristFamilyDetail.AddressId);
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", terroristFamilyDetail.RelationTypeId);
        return View(terroristFamilyDetail);
    }

    // GET: TerroristFamilyDetails/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.TerroristFamilyDetails == null)
        {
            return NotFound();
        }

        var terroristFamilyDetail = await _context.TerroristFamilyDetails.FindAsync(id);
        if (terroristFamilyDetail == null)
        {
            return NotFound();
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristFamilyDetail.AddressId);
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", terroristFamilyDetail.RelationTypeId);
        return View(terroristFamilyDetail);
    }

    // POST: TerroristFamilyDetails/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,IsDeleted,IsActive,AddressId,RelationTypeId")] TerroristFamilyDetail terroristFamilyDetail)
    {
        if (id != terroristFamilyDetail.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(terroristFamilyDetail);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerroristFamilyDetailExists(terroristFamilyDetail.Id))
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
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristFamilyDetail.AddressId);
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", terroristFamilyDetail.RelationTypeId);
        return View(terroristFamilyDetail);
    }

    // GET: TerroristFamilyDetails/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.TerroristFamilyDetails == null)
        {
            return NotFound();
        }

        var terroristFamilyDetail = await _context.TerroristFamilyDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristFamilyDetail == null)
        {
            return NotFound();
        }

        return View(terroristFamilyDetail);
    }

    // POST: TerroristFamilyDetails/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.TerroristFamilyDetails == null)
        {
            return Problem("Entity set 'IFCDbContext.TerroristFamilyDetails'  is null.");
        }
        var terroristFamilyDetail = await _context.TerroristFamilyDetails.FindAsync(id);
        if (terroristFamilyDetail != null)
        {
            _context.TerroristFamilyDetails.Remove(terroristFamilyDetail);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TerroristFamilyDetailExists(long id)
    {
        return _context.TerroristFamilyDetails.Any(e => e.Id == id);
    }
}
