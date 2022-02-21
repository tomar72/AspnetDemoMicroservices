using MediatR;

namespace UnitStatus.Application.Features.UnitStatus.Commands.SetUnitStatus
{
    public class SetUnitStatusCommand : IRequest<int>
    {
        public bool IsOnHold { get; set; }

        public string Description { get; set; }
    }
}
