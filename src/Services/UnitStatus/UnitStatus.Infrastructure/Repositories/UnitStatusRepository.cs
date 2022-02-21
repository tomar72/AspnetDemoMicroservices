using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitStatus.Application.Contracts.Persistence;
using UnitStatus.Infrastructure.Persistence;

namespace UnitStatus.Infrastructure.Repositories
{
    public class UnitStatusRepository : RepositoryBase<Domain.Entities.UnitStatus>, IUnitStatusRepository
    {
        public UnitStatusRepository(UnitStatusContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Domain.Entities.UnitStatus>> GetUnitStatusesByUnitId(string unitId)
        {
            var orderList = await _dbContext.UnitStatuses
                                        .Where(o => o.Description == unitId)
                                        .ToListAsync();
            return orderList;
        }
    }
}
