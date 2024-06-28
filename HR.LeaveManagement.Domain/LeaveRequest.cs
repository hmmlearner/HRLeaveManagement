﻿using HR.LeaveManagement.Domain.common;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest : BaseEntity
{
 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int DefaultDays { get; set; }

    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }
    public bool? Approved { get; set; }
    public bool? Cancelled { get; set;}

    public string RequestingEmpolyeeID { get; set; } = string.Empty;
}
