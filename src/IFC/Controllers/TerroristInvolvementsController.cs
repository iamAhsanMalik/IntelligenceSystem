using IFC.Infrastructure.Persistence;

namespace IFC.Controllers;

public class TerroristInvolvementsController : Controller
{
    private readonly IFCDbContext _context;

    public TerroristInvolvementsController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: TerroristInvolvements
    public async Task<IActionResult> Index()
    {
        return View(await _context.TerroristInvolvements.ToListAsync());
    }

    // GET: TerroristInvolvements/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.TerroristInvolvements == null)
        {
            return NotFound();
        }

        var terroristInvolvement = await _context.TerroristInvolvements
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristInvolvement == null)
        {
            return NotFound();
        }

        return View(terroristInvolvement);
    }

    // GET: TerroristInvolvements/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TerroristInvolvements/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Involvement,IsDeleted,IsActive")] TerroristInvolvement terroristInvolvement)
    {
        if (ModelState.IsValid)
        {
            _context.Add(terroristInvolvement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(terroristInvolvement);
    }

    // GET: TerroristInvolvements/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.TerroristInvolvements == null)
        {
            return NotFound();
        }

        var terroristInvolvement = await _context.TerroristInvolvements.FindAsync(id);
        if (terroristInvolvement == null)
        {
            return NotFound();
        }
        return View(terroristInvolvement);
    }

    // POST: TerroristInvolvements/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Involvement,IsDeleted,IsActive")] TerroristInvolvement terroristInvolvement)
    {
        if (id != terroristInvolvement.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(terroristInvolvement);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerroristInvolvementExists(terroristInvolvement.Id))
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
        return View(terroristInvolvement);
    }

    // GET: TerroristInvolvements/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.TerroristInvolvements == null)
        {
            return NotFound();
        }

        var terroristInvolvement = await _context.TerroristInvolvements
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristInvolvement == null)
        {
            return NotFound();
        }

        return View(terroristInvolvement);
    }

    // POST: TerroristInvolvements/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.TerroristInvolvements == null)
        {
            return Problem("Entity set 'IFCDbContext.TerroristInvolvements'  is null.");
        }
        var terroristInvolvement = await _context.TerroristInvolvements.FindAsync(id);
        if (terroristInvolvement != null)
        {
            _context.TerroristInvolvements.Remove(terroristInvolvement);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TerroristInvolvementExists(long id)
    {
        return _context.TerroristInvolvements.Any(e => e.Id == id);
    }
}
