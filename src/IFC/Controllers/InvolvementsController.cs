using IFC.Infrastructure.Persistence;

namespace IFC.Controllers;

public class InvolvementsController : Controller
{
    private readonly IFCDbContext _context;

    public InvolvementsController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: Involvements
    public async Task<IActionResult> Index()
    {
        return View(await _context.Involvements.ToListAsync());
    }

    // GET: Involvements/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Involvements == null)
        {
            return NotFound();
        }

        var involvement = await _context.Involvements
            .FirstOrDefaultAsync(m => m.Id == id);
        if (involvement == null)
        {
            return NotFound();
        }

        return View(involvement);
    }

    // GET: Involvements/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Involvements/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive")] Involvement involvement)
    {
        if (ModelState.IsValid)
        {
            _context.Add(involvement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(involvement);
    }

    // GET: Involvements/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Involvements == null)
        {
            return NotFound();
        }

        var involvement = await _context.Involvements.FindAsync(id);
        if (involvement == null)
        {
            return NotFound();
        }
        return View(involvement);
    }

    // POST: Involvements/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive")] Involvement involvement)
    {
        if (id != involvement.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(involvement);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvolvementExists(involvement.Id))
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
        return View(involvement);
    }

    // GET: Involvements/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Involvements == null)
        {
            return NotFound();
        }

        var involvement = await _context.Involvements
            .FirstOrDefaultAsync(m => m.Id == id);
        if (involvement == null)
        {
            return NotFound();
        }

        return View(involvement);
    }

    // POST: Involvements/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Involvements == null)
        {
            return Problem("Entity set 'IFCDbContext.Involvements'  is null.");
        }
        var involvement = await _context.Involvements.FindAsync(id);
        if (involvement != null)
        {
            _context.Involvements.Remove(involvement);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InvolvementExists(long id)
    {
        return _context.Involvements.Any(e => e.Id == id);
    }
}
