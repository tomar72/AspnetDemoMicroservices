namespace UnitStatus.Application.Features.UnitStatus.Queries.GetUnitStatusesList
{
    public class UnitStatusesVm
    {
        public int Id { get; protected set; }

        public bool IsOnHold { get; set; }

        public string Description { get; set; }
    }
}