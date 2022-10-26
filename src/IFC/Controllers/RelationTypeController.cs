namespace IFC.Controllers;

public class RelationTypeController : Controller
{
    private readonly IFCDbContext _context;

    public RelationTypeController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: RelationTypes
    public async Task<IActionResult> Index()
    {
        return View(await _context.RelationTypes.ToListAsync());
    }

    // GET: RelationTypes/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.RelationTypes == null)
        {
            return NotFound();
        }

        var relationType = await _context.RelationTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (relationType == null)
        {
            return NotFound();
        }

        return View(relationType);
    }

    // GET: RelationTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RelationTypes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,IsActive")] RelationType relationType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(relationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(relationType);
    }

    // GET: RelationTypes/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.RelationTypes == null)
        {
            return NotFound();
        }

        var relationType = await _context.RelationTypes.FindAsync(id);
        if (relationType == null)
        {
            return NotFound();
        }
        return View(relationType);
    }

    // POST: RelationTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsDeleted,IsActive")] RelationType relationType)
    {
        if (id != relationType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(relationType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationTypeExists(relationType.Id))
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
        return View(relationType);
    }

    // GET: RelationTypes/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.RelationTypes == null)
        {
            return NotFound();
        }

        var relationType = await _context.RelationTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (relationType == null)
        {
            return NotFound();
        }

        return View(relationType);
    }

    // POST: RelationTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.RelationTypes == null)
        {
            return Problem("Entity set 'IFCDbContext.RelationTypes'  is null.");
        }
        var relationType = await _context.RelationTypes.FindAsync(id);
        if (relationType != null)
        {
            _context.RelationTypes.Remove(relationType);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RelationTypeExists(long id)
    {
        return _context.RelationTypes.Any(e => e.Id == id);
    }
}
