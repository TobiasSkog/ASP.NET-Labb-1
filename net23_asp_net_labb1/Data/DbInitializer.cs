using net23_asp_net_labb1.Models;

namespace net23_asp_net_labb1.Data;

public static class DbInitializer
{
    private static readonly Random _random = new();
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Employees.Any())
        {
            return;
        }

        var employees = new Employee[]
        {
            new Employee{ Name = "Tobias Skog"},
            new Employee{ Name = "Reidar Nilsen"},
            new Employee{ Name = "Aldor Besher"},
            new Employee{ Name = "Emily Johnson"},
            new Employee{ Name = "Liam Smith"},
            new Employee{ Name = "Olivia Brown"},
            new Employee{ Name = "Noah Davis"},
            new Employee{ Name = "Emma Wilson"},
            new Employee{ Name = "Oliver Martinez"},
            new Employee{ Name = "Ava Anderson"},
            new Employee{ Name = "Elijah Taylor"},
            new Employee{ Name = "Charlotte Moore"},
            new Employee{ Name = "William Thompson"},
            new Employee{ Name = "Sophia Clark"},
            new Employee{ Name = "James Rodriguez"},
            new Employee{ Name = "Isabella Harris"},
            new Employee{ Name = "Benjamin Young"},
            new Employee{ Name = "Mia King"},
            new Employee{ Name = "Lucas Wright"},
            new Employee{ Name = "Harper Baker"},
            new Employee{ Name = "Henry Green"},
            new Employee{ Name = "Evelyn Carter"},
            new Employee{ Name = "Alexander Scott"}
        };

        foreach (var employee in employees)
        {
            context.Employees.Add(employee);
        }
        context.SaveChanges();

        List<LeaveApplication> leaveApplications = new();

        for (int i = 0; i < employees.Length - 5; i++)
        {
            var applicationDates = GenerateRandomDates();
            leaveApplications.Add(new()
            {
                StartDate = applicationDates.startDate,
                EndDate = applicationDates.endDate,
                ApplicationDate = applicationDates.applicationDate,
                LeaveType = (LeaveType)_random.Next(Enum.GetValues(typeof(LeaveType)).Length),
                ApplicationStatus = (ApplicationStatus)_random.Next(Enum.GetValues(typeof(ApplicationStatus)).Length),
                EmployeeId = employees[i].Id
            });
        }

        foreach (var leaveApplication in leaveApplications)
        {
            context.LeaveApplications.Add(leaveApplication);
        }
        context.SaveChanges();
        foreach (var leaveApplication in leaveApplications)
        {
            LeaveHistory leaveHistory = new()
            {
                EmployeeId = leaveApplication.EmployeeId,
                LeaveApplicationId = leaveApplication.Id
            };
            context.LeaveHistory.Add(leaveHistory);
        }
        context.SaveChanges();

    }

    private static (DateTime applicationDate, DateTime startDate, DateTime endDate) GenerateRandomDates()
    {

        DateTime applicationDate = DateTime.Now.AddDays(-_random.Next(1, 30));
        DateTime startDate = applicationDate.AddDays(_random.Next(1, 30));
        DateTime endDate = startDate.AddDays(_random.Next(1, 31));

        return (applicationDate, startDate, endDate);
    }
}
