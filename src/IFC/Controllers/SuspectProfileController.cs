namespace IFC.Controllers;

public class SuspectProfileController : Controller
{
    private readonly IFCDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public SuspectProfileController(IFCDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    // GET: SuspectProfiles
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.SuspectProfileRepo.GetSuspectProfilesAsync());
    }

    // GET: SuspectProfiles/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.SuspectProfiles == null)
        {
            return NotFound();
        }
        var suspectProfile = await _unitOfWork.SuspectProfileRepo.GetSuspectProfilesAsync(id);
        if (suspectProfile == null)
        {
            return NotFound();
        }

        return View(suspectProfile);
    }

    // GET: SuspectProfiles/Create
    public IActionResult Create()
    {
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id");
        ViewData["SuspectFamilyDetailsId"] = new SelectList(_context.SuspectFamilyDetails, "Id", "Id");
        return View();
    }

    // POST: SuspectProfiles/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,FatherName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,GeneralRemarks,IsDeleted,IsActive,AddressId,OrgnizationId,SuspectFamilyDetailsId")] SuspectProfile suspectProfile)
    {
        if (ModelState.IsValid)
        {
            _context.Add(suspectProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", suspectProfile.AddressId);
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id", suspectProfile.OrganizationId);
        ViewData["SuspectFamilyDetailsId"] = new SelectList(_context.SuspectFamilyDetails, "Id", "Id", suspectProfile.SuspectFamilyDetailsId);
        return View(suspectProfile);
    }

    // GET: SuspectProfiles/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.SuspectProfiles == null)
        {
            return NotFound();
        }

        var suspectProfile = await _context.SuspectProfiles.FindAsync(id);
        if (suspectProfile == null)
        {
            return NotFound();
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", suspectProfile.AddressId);
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id", suspectProfile.OrganizationId);
        ViewData["SuspectFamilyDetailsId"] = new SelectList(_context.SuspectFamilyDetails, "Id", "Id", suspectProfile.SuspectFamilyDetailsId);
        return View(suspectProfile);
    }

    // POST: SuspectProfiles/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,FatherName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,GeneralRemarks,IsDeleted,IsActive,AddressId,OrgnizationId,SuspectFamilyDetailsId")] SuspectProfile suspectProfile)
    {
        if (id != suspectProfile.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(suspectProfile);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspectProfileExists(suspectProfile.Id))
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
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", suspectProfile.AddressId);
        ViewData["OrgnizationId"] = new SelectList(_context.Organizations, "Id", "Id", suspectProfile.OrganizationId);
        ViewData["SuspectFamilyDetailsId"] = new SelectList(_context.SuspectFamilyDetails, "Id", "Id", suspectProfile.SuspectFamilyDetailsId);
        return View(suspectProfile);
    }

    // GET: SuspectProfiles/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.SuspectProfiles == null)
        {
            return NotFound();
        }

        var suspectProfile = await _context.SuspectProfiles
            .Include(s => s.Address)
            .Include(s => s.Organization)
            .Include(s => s.SuspectFamilyDetails)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (suspectProfile == null)
        {
            return NotFound();
        }

        return View(suspectProfile);
    }

    // POST: SuspectProfiles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.SuspectProfiles == null)
        {
            return Problem("Entity set 'IFCDbContext.SuspectProfiles'  is null.");
        }
        var suspectProfile = await _context.SuspectProfiles.FindAsync(id);
        if (suspectProfile != null)
        {
            _context.SuspectProfiles.Remove(suspectProfile);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SuspectProfileExists(long id)
    {
        return _context.SuspectProfiles.Any(e => e.Id == id);
    }
}
