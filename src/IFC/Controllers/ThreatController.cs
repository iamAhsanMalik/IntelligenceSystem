namespace IFC.Controllers;

public class ThreatController : Controller
{
    private readonly IFCDbContext _context;

    public ThreatController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Threats
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.Threats.Include(t => t.Incident).Include(t => t.Location).Include(t => t.Organization).Include(t => t.SuspectsProfile).Include(t => t.Wing).Take(25);
        return View(await iFCDbContext.ToListAsync());
    }

    public async Task<JsonResult> LoadData(string SearchCriteria, int LastRowId = 0, int? PageSize = 25, int? Direction = 0)
    {


        var iFCDbContext = _context.Threats.Include(t => t.Incident).Include(t => t.Location.Name.ToString()).Include(t => t.Organization.Name.ToString()).Include(t => t.SuspectsProfile.FullName.ToString()).Include(t => t.Wing.Name.ToString()).ToList();
        var result = iFCDbContext;
        return Json(new {status=true, Data=result });

    }

    // GET: Threats/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Threats == null)
        {
            return NotFound();
        }

        var threat = await _context.Threats
            .Include(t => t.Incident)
            .Include(t => t.Location)
            .Include(t => t.Organization)
            .Include(t => t.SuspectsProfile)
            .Include(t => t.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (threat == null)
        {
            return NotFound();
        }

        return View(threat);
    }

    // GET: Threats/Create
    public IActionResult Create()
    {
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id");
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id");
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id");
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id");
        return View();
    }

    // POST: Threats/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ThreatDate,ThreatLevel,IsDeleted,IsActive,WingId,OrganizationId,SuspectsProfileId,IncidentId,LocationId")] Threat threat)
    {
        if (ModelState.IsValid)
        {
            _context.Add(threat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id", threat.IncidentId);
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", threat.LocationId);
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", threat.OrganizationId);
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id", threat.SuspectsProfileId);
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id", threat.WingId);
        return View(threat);
    }

    // GET: Threats/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Threats == null)
        {
            return NotFound();
        }

        var threat = await _context.Threats.FindAsync(id);
        if (threat == null)
        {
            return NotFound();
        }
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id", threat.IncidentId);
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", threat.LocationId);
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", threat.OrganizationId);
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id", threat.SuspectsProfileId);
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id", threat.WingId);
        return View(threat);
    }

    // POST: Threats/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,ThreatDate,ThreatLevel,IsDeleted,IsActive,WingId,OrganizationId,SuspectsProfileId,IncidentId,LocationId")] Threat threat)
    {
        if (id != threat.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(threat);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreatExists(threat.Id))
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
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id", threat.IncidentId);
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", threat.LocationId);
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", threat.OrganizationId);
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id", threat.SuspectsProfileId);
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id", threat.WingId);
        return View(threat);
    }

    // GET: Threats/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Threats == null)
        {
            return NotFound();
        }

        var threat = await _context.Threats
            .Include(t => t.Incident)
            .Include(t => t.Location)
            .Include(t => t.Organization)
            .Include(t => t.SuspectsProfile)
            .Include(t => t.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (threat == null)
        {
            return NotFound();
        }

        return View(threat);
    }

    // POST: Threats/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Threats == null)
        {
            return Problem("Entity set 'IFCDbContext.Threats'  is null.");
        }
        var threat = await _context.Threats.FindAsync(id);
        if (threat != null)
        {
            _context.Threats.Remove(threat);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ThreatExists(long id)
    {
        return _context.Threats.Any(e => e.Id == id);
    }
}
