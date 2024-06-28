using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationWithDetails();
        Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);

        Task<bool> HasLeaveAllocation(int period, string userId, int leaveTypeId);
        Task AddLeaveAllocation(IEnumerable<LeaveAllocation> allocation);
        Task<LeaveAllocation> GetUserAllocations(string userID, int leaveTypeId);
    }
}
