using IFC.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace IFC.Controllers;

public class OrganizationsController : Controller
{
    private readonly IFCDbContext _context;

    public OrganizationsController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Organizations
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.Organizations.Include(o => o.Affiliate).Include(o => o.Involvement).Include(o => o.OperationalBase).Include(o => o.SocialMediaProfile);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: Organizations/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Organizations == null)
        {
            return NotFound();
        }

        var organization = await _context.Organizations
            .Include(o => o.Affiliate)
            .Include(o => o.Involvement)
            .Include(o => o.OperationalBase)
            .Include(o => o.SocialMediaProfile)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (organization == null)
        {
            return NotFound();
        }

        return View(organization);
    }

    // GET: Organizations/Create
    public IActionResult Create()
    {
        ViewData["AffiliateId"] = new SelectList(_context.Affiliates, "Id", "Id");
        ViewData["InvolvementId"] = new SelectList(_context.Involvements, "Id", "Id");
        ViewData["OperationalBaseId"] = new SelectList(_context.OperationalBases, "Id", "Id");
        ViewData["SocialMediaProfileId"] = new SelectList(_context.SocialMediaProfiles, "Id", "Id");
        return View();
    }

    // POST: Organizations/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,TotalMembers,YearFounded,ThreatLevel,Details,IsDeleted,IsActive,AffiliateId,OperationalBaseId,InvolvementId,SocialMediaProfileId")] Organization organization)
    {
        if (ModelState.IsValid)
        {
            _context.Add(organization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AffiliateId"] = new SelectList(_context.Affiliates, "Id", "Id", organization.AffiliateId);
        ViewData["InvolvementId"] = new SelectList(_context.Involvements, "Id", "Id", organization.InvolvementId);
        ViewData["OperationalBaseId"] = new SelectList(_context.OperationalBases, "Id", "Id", organization.OperationalBaseId);
        ViewData["SocialMediaProfileId"] = new SelectList(_context.SocialMediaProfiles, "Id", "Id", organization.SocialMediaProfileId);
        return View(organization);
    }

    // GET: Organizations/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Organizations == null)
        {
            return NotFound();
        }

        var organization = await _context.Organizations.FindAsync(id);
        if (organization == null)
        {
            return NotFound();
        }
        ViewData["AffiliateId"] = new SelectList(_context.Affiliates, "Id", "Id", organization.AffiliateId);
        ViewData["InvolvementId"] = new SelectList(_context.Involvements, "Id", "Id", organization.InvolvementId);
        ViewData["OperationalBaseId"] = new SelectList(_context.OperationalBases, "Id", "Id", organization.OperationalBaseId);
        ViewData["SocialMediaProfileId"] = new SelectList(_context.SocialMediaProfiles, "Id", "Id", organization.SocialMediaProfileId);
        return View(organization);
    }

    // POST: Organizations/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,TotalMembers,YearFounded,ThreatLevel,Details,IsDeleted,IsActive,AffiliateId,OperationalBaseId,InvolvementId,SocialMediaProfileId")] Organization organization)
    {
        if (id != organization.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(organization);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(organization.Id))
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
        ViewData["AffiliateId"] = new SelectList(_context.Affiliates, "Id", "Id", organization.AffiliateId);
        ViewData["InvolvementId"] = new SelectList(_context.Involvements, "Id", "Id", organization.InvolvementId);
        ViewData["OperationalBaseId"] = new SelectList(_context.OperationalBases, "Id", "Id", organization.OperationalBaseId);
        ViewData["SocialMediaProfileId"] = new SelectList(_context.SocialMediaProfiles, "Id", "Id", organization.SocialMediaProfileId);
        return View(organization);
    }

    // GET: Organizations/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Organizations == null)
        {
            return NotFound();
        }

        var organization = await _context.Organizations
            .Include(o => o.Affiliate)
            .Include(o => o.Involvement)
            .Include(o => o.OperationalBase)
            .Include(o => o.SocialMediaProfile)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (organization == null)
        {
            return NotFound();
        }

        return View(organization);
    }

    // POST: Organizations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Organizations == null)
        {
            return Problem("Entity set 'IFCDbContext.Organizations'  is null.");
        }
        var organization = await _context.Organizations.FindAsync(id);
        if (organization != null)
        {
            _context.Organizations.Remove(organization);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OrganizationExists(long id)
    {
        return _context.Organizations.Any(e => e.Id == id);
    }
}
