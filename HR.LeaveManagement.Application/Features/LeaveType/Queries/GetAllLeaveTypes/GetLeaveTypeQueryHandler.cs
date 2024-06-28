using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logger;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypeQueryHandler> _logger;

        public GetLeaveTypeQueryHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypeQueryHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            // Convert data objects to DTO objects

            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            _logger.LogInformation("leave types logged sucessfully");
            //return the list of DTO
            return data;
        }
    }
}
