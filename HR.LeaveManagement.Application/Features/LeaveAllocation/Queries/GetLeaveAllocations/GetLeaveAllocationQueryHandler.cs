using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logger;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationQueryHandler : IRequestHandler<GetLeaveAllocationQuery, List<LeaveAllocationDto>>
    {
        private IMapper _mapper;
        private ILeaveAllocationRepository _leaveAllocationRepository;

        public GetLeaveAllocationQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetAllAsync();
            var leaveAll = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

            return leaveAll;
        }
    }
}
