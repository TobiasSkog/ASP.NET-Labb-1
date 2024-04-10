using System.ComponentModel.DataAnnotations;

namespace net23_asp_net_labb1.Models;
public class Employee
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    public string Name { get; set; }

    public ICollection<LeaveHistory> LeaveHistories { get; set; } = new List<LeaveHistory>();
    public ICollection<LeaveApplication> LeaveApplications { get; set; } = new List<LeaveApplication>();
}
