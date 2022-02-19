using UnitStatus.Domain.Common;

namespace UnitStatus.Domain.Entities
{
    public class UnitStatus : EntityBase
    {
        public bool IsOnHold {  get; set; }

        public string Description { get; set; }
    }
}
