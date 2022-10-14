using IFC.Infrastructure.Persistence;

namespace IFC.Controllers;

public class AffiliatesController : Controller
{
    private readonly IFCDbContext _context;

    public AffiliatesController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Affiliate
    public async Task<IActionResult> Index()
    {
        return View(await _context.Affiliates.ToListAsync());
    }

    // GET: Affiliate/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Affiliates == null)
        {
            return NotFound();
        }

        var affiliate = await _context.Affiliates
            .FirstOrDefaultAsync(m => m.Id == id);
        if (affiliate == null)
        {
            return NotFound();
        }

        return View(affiliate);
    }

    // GET: Affiliate/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Affiliate/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,LocalAffiliate,ForiegnAffiliate,IsDeleted,IsActive")] Affiliate affiliate)
    {
        if (ModelState.IsValid)
        {
            _context.Add(affiliate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(affiliate);
    }

    // GET: Affiliate/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Affiliates == null)
        {
            return NotFound();
        }

        var affiliate = await _context.Affiliates.FindAsync(id);
        if (affiliate == null)
        {
            return NotFound();
        }
        return View(affiliate);
    }

    // POST: Affiliate/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,LocalAffiliate,ForiegnAffiliate,IsDeleted,IsActive")] Affiliate affiliate)
    {
        if (id != affiliate.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(affiliate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AffiliateExists(affiliate.Id))
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
        return View(affiliate);
    }

    // GET: Affiliate/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Affiliates == null)
        {
            return NotFound();
        }

        var affiliate = await _context.Affiliates
            .FirstOrDefaultAsync(m => m.Id == id);
        if (affiliate == null)
        {
            return NotFound();
        }

        return View(affiliate);
    }

    // POST: Affiliate/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Affiliates == null)
        {
            return Problem("Entity set 'IFCDbContext.Affiliates'  is null.");
        }
        var affiliate = await _context.Affiliates.FindAsync(id);
        if (affiliate != null)
        {
            _context.Affiliates.Remove(affiliate);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AffiliateExists(long id)
    {
        return _context.Affiliates.Any(e => e.Id == id);
    }
}
