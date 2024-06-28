using HR.LeaveManagement.Domain.common;

namespace HR.LeaveManagement.Domain
{
    public class LeaveAllocation: BaseEntity
    {
        public string NumberOfDays { get; set; } = string.Empty;
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

        public string EmployeeId { get; set; } = string.Empty;
    }
}
