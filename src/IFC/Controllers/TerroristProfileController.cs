namespace IFC.Controllers;

public class TerroristProfileController : Controller
{
    private readonly IFCDbContext _context;

    public TerroristProfileController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: TerroristProfiles
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.TerroristProfiles.Include(t => t.Address).Include(t => t.Orgnization).Include(t => t.TerroristFacilitatorsDetails).Include(t => t.TerroristFamilyDetails).Include(t => t.TerroristInvolvement);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: TerroristProfiles/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.TerroristProfiles == null)
        {
            return NotFound();
        }

        var terroristProfile = await _context.TerroristProfiles
            .Include(t => t.Address)
            .Include(t => t.Orgnization)
            .Include(t => t.TerroristFacilitatorsDetails)
            .Include(t => t.TerroristFamilyDetails)
            .Include(t => t.TerroristInvolvement)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristProfile == null)
        {
            return NotFound();
        }

        return View(terroristProfile);
    }

    // GET: TerroristProfiles/Create
    public IActionResult Create()
    {
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id");
        ViewData["TerroristFacilitatorsDetailsId"] = new SelectList(_context.TerroristFacilitatorsDetails, "Id", "Id");
        ViewData["TerroristFamilyDetailsId"] = new SelectList(_context.TerroristFamilyDetails, "Id", "Id");
        ViewData["TerroristInvolvementId"] = new SelectList(_context.TerroristInvolvements, "Id", "Id");
        return View();
    }

    // POST: TerroristProfiles/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,NameAlias,FatherName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,IsFounder,GeneralRemarks,IsDeleted,IsActive,AddressId,OrgnizationId,TerroristInvolvementId,TerroristFamilyDetailsId,TerroristFacilitatorsDetailsId")] TerroristProfile terroristProfile)
    {
        if (ModelState.IsValid)
        {
            _context.Add(terroristProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristProfile.AddressId);
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id", terroristProfile.OrgnizationId);
        ViewData["TerroristFacilitatorsDetailsId"] = new SelectList(_context.TerroristFacilitatorsDetails, "Id", "Id", terroristProfile.TerroristFacilitatorsDetailsId);
        ViewData["TerroristFamilyDetailsId"] = new SelectList(_context.TerroristFamilyDetails, "Id", "Id", terroristProfile.TerroristFamilyDetailsId);
        ViewData["TerroristInvolvementId"] = new SelectList(_context.TerroristInvolvements, "Id", "Id", terroristProfile.TerroristInvolvementId);
        return View(terroristProfile);
    }

    // GET: TerroristProfiles/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.TerroristProfiles == null)
        {
            return NotFound();
        }

        var terroristProfile = await _context.TerroristProfiles.FindAsync(id);
        if (terroristProfile == null)
        {
            return NotFound();
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristProfile.AddressId);
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id", terroristProfile.OrgnizationId);
        ViewData["TerroristFacilitatorsDetailsId"] = new SelectList(_context.TerroristFacilitatorsDetails, "Id", "Id", terroristProfile.TerroristFacilitatorsDetailsId);
        ViewData["TerroristFamilyDetailsId"] = new SelectList(_context.TerroristFamilyDetails, "Id", "Id", terroristProfile.TerroristFamilyDetailsId);
        ViewData["TerroristInvolvementId"] = new SelectList(_context.TerroristInvolvements, "Id", "Id", terroristProfile.TerroristInvolvementId);
        return View(terroristProfile);
    }

    // POST: TerroristProfiles/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,NameAlias,FatherName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,IsFounder,GeneralRemarks,IsDeleted,IsActive,AddressId,OrgnizationId,TerroristInvolvementId,TerroristFamilyDetailsId,TerroristFacilitatorsDetailsId")] TerroristProfile terroristProfile)
    {
        if (id != terroristProfile.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(terroristProfile);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerroristProfileExists(terroristProfile.Id))
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
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristProfile.AddressId);
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id", terroristProfile.OrgnizationId);
        ViewData["TerroristFacilitatorsDetailsId"] = new SelectList(_context.TerroristFacilitatorsDetails, "Id", "Id", terroristProfile.TerroristFacilitatorsDetailsId);
        ViewData["TerroristFamilyDetailsId"] = new SelectList(_context.TerroristFamilyDetails, "Id", "Id", terroristProfile.TerroristFamilyDetailsId);
        ViewData["TerroristInvolvementId"] = new SelectList(_context.TerroristInvolvements, "Id", "Id", terroristProfile.TerroristInvolvementId);
        return View(terroristProfile);
    }

    // GET: TerroristProfiles/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.TerroristProfiles == null)
        {
            return NotFound();
        }

        var terroristProfile = await _context.TerroristProfiles
            .Include(t => t.Address)
            .Include(t => t.Orgnization)
            .Include(t => t.TerroristFacilitatorsDetails)
            .Include(t => t.TerroristFamilyDetails)
            .Include(t => t.TerroristInvolvement)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristProfile == null)
        {
            return NotFound();
        }

        return View(terroristProfile);
    }

    // POST: TerroristProfiles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.TerroristProfiles == null)
        {
            return Problem("Entity set 'IFCDbContext.TerroristProfiles'  is null.");
        }
        var terroristProfile = await _context.TerroristProfiles.FindAsync(id);
        if (terroristProfile != null)
        {
            _context.TerroristProfiles.Remove(terroristProfile);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TerroristProfileExists(long id)
    {
        return _context.TerroristProfiles.Any(e => e.Id == id);
    }
}
