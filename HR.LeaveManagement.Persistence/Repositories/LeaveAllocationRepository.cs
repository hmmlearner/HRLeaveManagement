using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDatabaseContext hrContext) : base(hrContext)
        {
        }

        Task ILeaveAllocationRepository.AddLeaveAllocation(IEnumerable<LeaveAllocation> allocation)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _hrContext.LeaveAllocation
                                    .Include(l => l.LeaveType)
                                    .FirstOrDefaultAsync(l => l.Id == id);
            return leaveAllocation ?? throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _hrContext.LeaveAllocation
                                    .Include(p => p.LeaveType)
                                    .ToListAsync();
            return leaveAllocations;
        }

        public async Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocation = await _hrContext.LeaveAllocation
                                    .Include(l => l.LeaveType)
                                    .Where(p => p.EmployeeId == userId)
                                    .ToListAsync();
            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userID, int leaveTypeId)
        {
            var leaveAllocation = await _hrContext.LeaveAllocation
                    .Include(l => l.LeaveType)
                    .FirstOrDefaultAsync(p => p.EmployeeId == userID
                            && p.LeaveTypeId == leaveTypeId);
            return leaveAllocation;
        }

        public async Task<bool> HasLeaveAllocation(int period, string userId, int leaveTypeId)
        {
            return await _hrContext.LeaveAllocation
                                .AnyAsync(p => p.EmployeeId.Equals(userId)
                                        && p.LeaveTypeId == leaveTypeId
                                        && p.Period == period);
            
        }
    }

}
