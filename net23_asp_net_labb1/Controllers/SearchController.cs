using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net23_asp_net_labb1.Data;
using net23_asp_net_labb1.Models;
using System.Globalization;

namespace net23_asp_net_labb1.Controllers;
public class SearchController : Controller
{
    private readonly ApplicationDbContext _context;
    public SearchController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Search()
    {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Search(int? id)
    {
        if (id != null)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {

                LeaveApplication? leaveApplication = _context.LeaveApplications.FirstOrDefault(model =>
                    model.EmployeeId == employee.Id && model.StartDate >= DateTime.Now);

                SearchEmployeeViewModel searchEmployee = new()
                {
                    Employee = employee,
                    LeaveApplication = leaveApplication,
                    HaveActiveLeaveApplication = leaveApplication != null
                };

                return View("SearchResult", searchEmployee);
            }
        }

        return RedirectToAction("Search");
    }


    [HttpGet]
    public IActionResult SearchResult(SearchEmployeeViewModel searchEmployee)
    {
        return View(searchEmployee);
    }




    [HttpGet]
    public IActionResult FilterDates()
    {
        List<SelectListItem> months = new();
        for (int i = 1; i <= 12; i++)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

            months.Add(new SelectListItem
            {
                Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(monthName),
                Value = i.ToString()
            });
        }

        ViewBag.Months = months;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> FilterDates(int month)
    {
        List<LeaveApplication> leaveApplications = await _context.LeaveApplications
            .Where(la => la.ApplicationDate.Month == month)
            .Include(la => la.Employee)
            .ToListAsync();
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

        FilterDateViewModel filterDate = new()
        {
            LeaveApplications = leaveApplications,
            FilteredByMonth = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(monthName)
        };


        return View("FilterDatesResult", filterDate);
    }

    public IActionResult FilterDatesResult(FilterDateViewModel filterDate)
    {
        return View(filterDate);
    }
}
