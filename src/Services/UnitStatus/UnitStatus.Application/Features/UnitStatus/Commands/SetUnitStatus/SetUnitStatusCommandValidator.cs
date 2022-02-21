using FluentValidation;

namespace UnitStatus.Application.Features.UnitStatus.Commands.SetUnitStatus
{
    public class SetUnitStatusCommandValidator : AbstractValidator<SetUnitStatusCommand>
    {
        public SetUnitStatusCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{Description} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Description} must not exceed 50 charactes.");

            RuleFor(p => p.IsOnHold)
                .NotEmpty().WithMessage("{IsOnHold} is required.");
        }
    }
}
