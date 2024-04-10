namespace net23_asp_net_labb1.Models;
public class LeaveHistory
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int LeaveApplicationId { get; set; }

    public Employee? Employee { get; set; }
    public LeaveApplication? LeaveApplication { get; set; }
}
