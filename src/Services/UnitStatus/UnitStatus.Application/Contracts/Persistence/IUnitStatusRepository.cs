using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitStatus.Application.Contracts.Persistence
{
    public interface IUnitStatusRepository : IAsyncRepository<Domain.Entities.UnitStatus>
    {
        Task<IEnumerable<Domain.Entities.UnitStatus>> GetUnitStatusesByUnitId(string unitId);
    }
}
