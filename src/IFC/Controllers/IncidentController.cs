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


    // GET: Incidents
    public async Task<IActionResult> LoadIncidentData()
    {
        var iFCDbContext = _context.Incidents.Include(i => i.Location).Include(i => i.Organization).Include(i => i.SuspectsProfile).Include(i => i.Wing);
        var incidentsResults = await iFCDbContext.ToListAsync();
        int recordsTotal = 0;
        recordsTotal = incidentsResults.Count();
        var data = incidentsResults.Skip(0).Take(0).ToList();
        var jsonData = new { recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
        return Ok(jsonData);
        //return View();
    }

    /// <summary>Loads the table.</summary>
    /// <param name="dtParameters">The dt parameters.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    [HttpPost("LoadTable")]
    public async Task<IActionResult> LoadTable([FromBody] DtParameters dtParameters)
    {
        var searchBy = dtParameters.Search?.Value;

        // if we have an empty search then just order the results by Id ascending
        var orderCriteria = "Id";
        var orderAscendingDirection = true;

        if (dtParameters.Order != null)
        {
            // in this example we just default sort on the 1st column
            orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
            orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
        }

        var result = _context.Incidents.AsQueryable();

        if (!string.IsNullOrEmpty(searchBy))
        {
            result = result.Where(r => r.Location.Name != null && r.Location.Name.ToUpper().Contains(searchBy.ToUpper()) ||
                                       r.Organization.Name != null && r.Organization.Name.ToUpper().Contains(searchBy.ToUpper()) ||
                                       r.SuspectsProfile.FullName != null && r.SuspectsProfile.FullName.ToUpper().Contains(searchBy.ToUpper()));
        }

        result = orderAscendingDirection ? result.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : result.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

        // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
        var filteredResultsCount = await result.CountAsync();
        var totalResultsCount = await _context.Incidents.CountAsync();
        var incidentData = Json(new DtResult<Incident>
        {
            Draw = dtParameters.Draw,
            RecordsTotal = totalResultsCount,
            RecordsFiltered = filteredResultsCount,
            Data = await result
                .Skip(dtParameters.Start)
                .Take(dtParameters.Length)
                .ToListAsync()
        });
        return incidentData;
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
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
        ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Name");
        ViewData["SuspectsProfileId"] = new SelectList(_context.SuspectProfiles, "Id", "FullName");
        ViewData["WingId"] = new SelectList(_context.Wings, "Id", "Name");
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
