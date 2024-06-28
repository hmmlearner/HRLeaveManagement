using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommanderValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommanderValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{propertyName} is required field")
                .NotNull()
                .MaximumLength(70).WithMessage("{propertyName} must be fewer than 70 characters");
            RuleFor(c => c.DefaultDays)
                .GreaterThan(0).WithMessage("{propertyName} should be atleast a day")
                .LessThan(100).WithMessage("{propertyName} should be not be greater than 100 days");

            RuleFor(p => p)
                .MustAsync(LeaveTypeUnique)
                .WithMessage("Leave Type already exists");

        }

        private Task<bool> LeaveTypeUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
