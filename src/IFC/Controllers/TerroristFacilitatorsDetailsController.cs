using IFC.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IFC.Controllers;

public class TerroristFacilitatorsDetailsController : Controller
{
    private readonly IFCDbContext _context;

    public TerroristFacilitatorsDetailsController(IFCDbContext context)
    {
        _context = context;
    }

    // GET: TerroristFacilitatorsDetails
    public async Task<IActionResult> Index()
    {
        var iFCDbContext = _context.TerroristFacilitatorsDetails.Include(t => t.Address).Include(t => t.RelationType);
        return View(await iFCDbContext.ToListAsync());
    }

    // GET: TerroristFacilitatorsDetails/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.TerroristFacilitatorsDetails == null)
        {
            return NotFound();
        }

        var terroristFacilitatorsDetail = await _context.TerroristFacilitatorsDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristFacilitatorsDetail == null)
        {
            return NotFound();
        }

        return View(terroristFacilitatorsDetail);
    }

    // GET: TerroristFacilitatorsDetails/Create
    public IActionResult Create()
    {
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id");
        return View();
    }

    // POST: TerroristFacilitatorsDetails/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,IsDeleted,IsActive,AddressId,RelationTypeId")] TerroristFacilitatorsDetail terroristFacilitatorsDetail)
    {
        if (ModelState.IsValid)
        {
            _context.Add(terroristFacilitatorsDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristFacilitatorsDetail.AddressId);
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", terroristFacilitatorsDetail.RelationTypeId);
        return View(terroristFacilitatorsDetail);
    }

    // GET: TerroristFacilitatorsDetails/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.TerroristFacilitatorsDetails == null)
        {
            return NotFound();
        }

        var terroristFacilitatorsDetail = await _context.TerroristFacilitatorsDetails.FindAsync(id);
        if (terroristFacilitatorsDetail == null)
        {
            return NotFound();
        }
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristFacilitatorsDetail.AddressId);
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", terroristFacilitatorsDetail.RelationTypeId);
        return View(terroristFacilitatorsDetail);
    }

    // POST: TerroristFacilitatorsDetails/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,DateOfBirth,TribeOrCast,Sect,CNIC,Passport,MaritalStatus,IsDeleted,IsActive,AddressId,RelationTypeId")] TerroristFacilitatorsDetail terroristFacilitatorsDetail)
    {
        if (id != terroristFacilitatorsDetail.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(terroristFacilitatorsDetail);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerroristFacilitatorsDetailExists(terroristFacilitatorsDetail.Id))
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
        ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", terroristFacilitatorsDetail.AddressId);
        ViewData["RelationTypeId"] = new SelectList(_context.RelationTypes, "Id", "Id", terroristFacilitatorsDetail.RelationTypeId);
        return View(terroristFacilitatorsDetail);
    }

    // GET: TerroristFacilitatorsDetails/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.TerroristFacilitatorsDetails == null)
        {
            return NotFound();
        }

        var terroristFacilitatorsDetail = await _context.TerroristFacilitatorsDetails
            .Include(t => t.Address)
            .Include(t => t.RelationType)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (terroristFacilitatorsDetail == null)
        {
            return NotFound();
        }

        return View(terroristFacilitatorsDetail);
    }

    // POST: TerroristFacilitatorsDetails/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.TerroristFacilitatorsDetails == null)
        {
            return Problem("Entity set 'IFCDbContext.TerroristFacilitatorsDetails'  is null.");
        }
        var terroristFacilitatorsDetail = await _context.TerroristFacilitatorsDetails.FindAsync(id);
        if (terroristFacilitatorsDetail != null)
        {
            _context.TerroristFacilitatorsDetails.Remove(terroristFacilitatorsDetail);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TerroristFacilitatorsDetailExists(long id)
    {
        return _context.TerroristFacilitatorsDetails.Any(e => e.Id == id);
    }
}
