using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logger;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery,LeaveAllocationDetailsDto>
    {
        private IMapper _mapper;
        private ILeaveAllocationRepository _leaveAllocation;

        public GetLeaveAllocationDetailsQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveAllocation = leaveAllocationRepository;
        }

        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocation.GetLeaveAllocationWithDetails(request.Id);
            if(leaveAllocation == null)
            {
                throw new NotFoundException(nameof(leaveAllocation), request.Id);
            }

            var leaveAllocationDTO = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
            return leaveAllocationDTO;
        }
    }
}
