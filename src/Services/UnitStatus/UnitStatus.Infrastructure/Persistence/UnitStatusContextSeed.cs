using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitStatus.Infrastructure.Persistence
{
    public class UnitStatusContextSeed
    {
        public static async Task SeedAsync(UnitStatusContext unittatusContext, ILogger<UnitStatusContextSeed> logger)
        {
            if (!unittatusContext.UnitStatuses.Any())
            {
                unittatusContext.UnitStatuses.AddRange(GetPreconfiguredStatuses());
                await unittatusContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(UnitStatusContext).Name);
            }
        }

        private static IEnumerable<Domain.Entities.UnitStatus> GetPreconfiguredStatuses()
        {
            return new List<Domain.Entities.UnitStatus>{
                new Domain.Entities.UnitStatus() { Description = "My test unit status", IsOnHold = false } 
            };
        }
    }
}
