using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommanderValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommanderValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(c => c.Id)
                .NotNull()
                .MustAsync(LeaveTypeMustExists);
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{propertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{propertyName} must not exceed 70 characters in lenght");
            RuleFor(c => c.DefaultDays)
                .GreaterThan(0).WithMessage("{propertyName} must be atleast 1 day")
                .LessThan(100).WithMessage("{propertyName} should be not be greater than 100 days");

            RuleFor(p => p)
                .MustAsync(LeaveTypeUnique)
                .WithMessage("Leave Type already exists");

        }

        public async Task<bool> LeaveTypeMustExists(int id, CancellationToken token)
        {
            var leaveType = _leaveTypeRepository.GetAsync(id);
            return leaveType != null;
        }
        private Task<bool> LeaveTypeUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }


    }
}
