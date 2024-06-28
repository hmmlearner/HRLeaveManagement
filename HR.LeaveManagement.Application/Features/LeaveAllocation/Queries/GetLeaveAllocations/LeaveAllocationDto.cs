﻿using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class LeaveAllocationDto
    {
        public int Id { get; set; }
        public string NumberOfDays { get; set; } = string.Empty;
        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

        public string EmployeeId { get; set; } = string.Empty;
    }
}
