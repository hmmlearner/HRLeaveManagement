using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{

    internal class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validation = new CreateLeaveTypeCommanderValidator(_leaveTypeRepository);
            var validationResult = await validation.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Leave invalid", validationResult);
            }

            //Convert to domain object
            var leaveTypeCreate = _mapper.Map<Domain.LeaveType>(request);
            //save to database
            var leaveType = await _leaveTypeRepository.CreateAsync(leaveTypeCreate);

            //return id;
            return leaveType.Id;
        }
    }
}
