using IFC.Infrastructure.Persistence;

namespace IFC.Controllers;

public class SocialMediaProfilesController : Controller
{
    private readonly IFCDbContext _context;

    public SocialMediaProfilesController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: SocialMediaProfiles
    public async Task<IActionResult> Index()
    {
        return View(await _context.SocialMediaProfiles.ToListAsync());
    }

    // GET: SocialMediaProfiles/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.SocialMediaProfiles == null)
        {
            return NotFound();
        }

        var socialMediaProfile = await _context.SocialMediaProfiles
            .FirstOrDefaultAsync(m => m.Id == id);
        if (socialMediaProfile == null)
        {
            return NotFound();
        }

        return View(socialMediaProfile);
    }

    // GET: SocialMediaProfiles/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SocialMediaProfiles/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive")] SocialMediaProfile socialMediaProfile)
    {
        if (ModelState.IsValid)
        {
            _context.Add(socialMediaProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(socialMediaProfile);
    }

    // GET: SocialMediaProfiles/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.SocialMediaProfiles == null)
        {
            return NotFound();
        }

        var socialMediaProfile = await _context.SocialMediaProfiles.FindAsync(id);
        if (socialMediaProfile == null)
        {
            return NotFound();
        }
        return View(socialMediaProfile);
    }

    // POST: SocialMediaProfiles/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive")] SocialMediaProfile socialMediaProfile)
    {
        if (id != socialMediaProfile.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(socialMediaProfile);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialMediaProfileExists(socialMediaProfile.Id))
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
        return View(socialMediaProfile);
    }

    // GET: SocialMediaProfiles/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.SocialMediaProfiles == null)
        {
            return NotFound();
        }

        var socialMediaProfile = await _context.SocialMediaProfiles
            .FirstOrDefaultAsync(m => m.Id == id);
        if (socialMediaProfile == null)
        {
            return NotFound();
        }

        return View(socialMediaProfile);
    }

    // POST: SocialMediaProfiles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.SocialMediaProfiles == null)
        {
            return Problem("Entity set 'IFCDbContext.SocialMediaProfiles'  is null.");
        }
        var socialMediaProfile = await _context.SocialMediaProfiles.FindAsync(id);
        if (socialMediaProfile != null)
        {
            _context.SocialMediaProfiles.Remove(socialMediaProfile);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SocialMediaProfileExists(long id)
    {
        return _context.SocialMediaProfiles.Any(e => e.Id == id);
    }
}
