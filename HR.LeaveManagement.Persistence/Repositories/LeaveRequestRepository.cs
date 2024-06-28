using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDatabaseContext hrContext) : base(hrContext)
        {
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _hrContext.LeaveRequests
                                .Include(q => q.LeaveType)
                                .ToListAsync();
            return leaveRequests;
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _hrContext.LeaveRequests
                                .Include(q => q.LeaveType)
                                .Where(p => p.RequestingEmpolyeeID == userId)
                                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _hrContext.LeaveRequests
                                .Include(q => q.LeaveType)
                                .FirstOrDefaultAsync(x => x.Id == id);
                                
            return leaveRequest;
        }

       
    }

}
