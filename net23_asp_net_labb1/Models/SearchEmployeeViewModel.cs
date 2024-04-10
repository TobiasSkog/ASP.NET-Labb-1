using System.ComponentModel;

namespace net23_asp_net_labb1.Models;

public class SearchEmployeeViewModel
{
    public Employee Employee { get; set; }

    [DisplayName("Leave application")]
    public LeaveApplication? LeaveApplication { get; set; }

    [DisplayName("Have an active leave application")]
    public bool HaveActiveLeaveApplication { get; set; }
}
