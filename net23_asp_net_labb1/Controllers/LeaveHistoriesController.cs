using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net23_asp_net_labb1.Data;

namespace net23_asp_net_labb1.Controllers
{
    public class LeaveHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveHistory.Include(l => l.Employee).Include(l => l.LeaveApplication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaveHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveHistory = await _context.LeaveHistory
                .Include(l => l.Employee)
                .Include(l => l.LeaveApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveHistory == null)
            {
                return NotFound();
            }

            return View(leaveHistory);
        }

        //    // GET: LeaveHistories/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
        //        ViewData["LeaveApplicationId"] = new SelectList(_context.LeaveApplications, "Id", "Id");
        //        return View();
        //    }

        //    // POST: LeaveHistories/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,EmployeeId,LeaveApplicationId")] LeaveHistory leaveHistory)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(leaveHistory);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", leaveHistory.EmployeeId);
        //        ViewData["LeaveApplicationId"] = new SelectList(_context.LeaveApplications, "Id", "Id", leaveHistory.LeaveApplicationId);
        //        return View(leaveHistory);
        //    }

        //    // GET: LeaveHistories/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var leaveHistory = await _context.LeaveHistory.FindAsync(id);
        //        if (leaveHistory == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", leaveHistory.EmployeeId);
        //        ViewData["LeaveApplicationId"] = new SelectList(_context.LeaveApplications, "Id", "Id", leaveHistory.LeaveApplicationId);
        //        return View(leaveHistory);
        //    }

        //    // POST: LeaveHistories/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,LeaveApplicationId")] LeaveHistory leaveHistory)
        //    {
        //        if (id != leaveHistory.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(leaveHistory);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!LeaveHistoryExists(leaveHistory.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", leaveHistory.EmployeeId);
        //        ViewData["LeaveApplicationId"] = new SelectList(_context.LeaveApplications, "Id", "Id", leaveHistory.LeaveApplicationId);
        //        return View(leaveHistory);
        //    }

        //    // GET: LeaveHistories/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var leaveHistory = await _context.LeaveHistory
        //            .Include(l => l.Employee)
        //            .Include(l => l.LeaveApplication)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (leaveHistory == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(leaveHistory);
        //    }

        //    // POST: LeaveHistories/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var leaveHistory = await _context.LeaveHistory.FindAsync(id);
        //        if (leaveHistory != null)
        //        {
        //            _context.LeaveHistory.Remove(leaveHistory);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool LeaveHistoryExists(int id)
        //    {
        //        return _context.LeaveHistory.Any(e => e.Id == id);
        //    }
    }
}
