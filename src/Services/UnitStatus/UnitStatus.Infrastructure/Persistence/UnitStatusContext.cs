using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitStatus.Domain.Common;

namespace UnitStatus.Infrastructure.Persistence
{
    public class UnitStatusContext : DbContext
    {
        public UnitStatusContext(DbContextOptions<UnitStatusContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.UnitStatus> UnitStatuses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "swm";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "swm";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
