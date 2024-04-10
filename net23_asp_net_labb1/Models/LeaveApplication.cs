using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace net23_asp_net_labb1.Models;
public enum ApplicationStatus
{
    [Display(Name = "Pending")]
    Pending,

    [Display(Name = "Approved")]
    Approved,

    [Display(Name = "Declined")]
    Declined,

    [Display(Name = "Cancelled")]
    Cancelled
}
public enum LeaveType
{
    [Display(Name = "Vacation Leave")]
    VacationLeave,

    [Display(Name = "Parental Leave")]
    ParentalLeave,

    [Display(Name = "Sick Leave")]
    SickLeave,

    [Display(Name = "Personal Leave")]
    PersonalLeave,

    [Display(Name = "Other")]
    Other
}
public class LeaveApplication
{
    public int Id { get; set; }

    [DisplayName("Start date")]
    public DateTime StartDate { get; set; }

    [DisplayName("End date")]
    public DateTime EndDate { get; set; }

    [DisplayName("Application date")]
    public DateTime ApplicationDate { get; set; } = DateTime.Now;

    [DisplayName("Leave type")]
    public LeaveType? LeaveType { get; set; }

    [DisplayName("Application status")]
    public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Pending;

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
