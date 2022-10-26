namespace IFC.Controllers;

public class IncidentController : Controller
{
    private readonly IFCDbContext _context;

    public IncidentController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Incidents
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.Incidents.Include(i => i.Location).Include(i => i.Organization).Include(i => i.SuspectsProfile).Include(i => i.Wing);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: Incidents/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Incidents == null)
        {
            return NotFound();
        }

        var incident = await _context.Incidents
            .Include(i => i.Location)
            .Include(i => i.Organization)
            .Include(i => i.SuspectsProfile)
            .Include(i => i.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (incident == null)
        {
            return NotFound();
        }

        return View(incident);
    }

    // GET: Incidents/Create
    public IActionResult Create()
    {
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id");
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id");
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id");
        return View();
    }

    // POST: Incidents/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,IncidentDate,IsDeleted,IsActive,SuspectsProfileId,OrganizationId,WingId,LocationId")] Incident incident)
    {
        if (ModelState.IsValid)
        {
            _context.Add(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", incident.LocationId);
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", incident.OrganizationId);
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id", incident.SuspectsProfileId);
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id", incident.WingId);
        return View(incident);
    }

    // GET: Incidents/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Incidents == null)
        {
            return NotFound();
        }

        var incident = await _context.Incidents.FindAsync(id);
        if (incident == null)
        {
            return NotFound();
        }
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", incident.LocationId);
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", incident.OrganizationId);
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id", incident.SuspectsProfileId);
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id", incident.WingId);
        return View(incident);
    }

    // POST: Incidents/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,IncidentDate,IsDeleted,IsActive,SuspectsProfileId,OrganizationId,WingId,LocationId")] Incident incident)
    {
        if (id != incident.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(incident);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(incident.Id))
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
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", incident.LocationId);
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", incident.OrganizationId);
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "Id", incident.SuspectsProfileId);
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Id", incident.WingId);
        return View(incident);
    }

    // GET: Incidents/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Incidents == null)
        {
            return NotFound();
        }

        var incident = await _context.Incidents
            .Include(i => i.Location)
            .Include(i => i.Organization)
            .Include(i => i.SuspectsProfile)
            .Include(i => i.Wing)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (incident == null)
        {
            return NotFound();
        }

        return View(incident);
    }

    // POST: Incidents/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Incidents == null)
        {
            return Problem("Entity set 'IFCDbContext.Incidents'  is null.");
        }
        var incident = await _context.Incidents.FindAsync(id);
        if (incident != null)
        {
            _context.Incidents.Remove(incident);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool IncidentExists(long id)
    {
        return _context.Incidents.Any(e => e.Id == id);
    }
}
