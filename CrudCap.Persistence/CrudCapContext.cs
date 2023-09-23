using CrudCap.Domain.Entities;
using CrudCap.Domain.Entities.Location;
using CrudCap.Domain.Entities.Propertie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CrudCap.Persistence
{
    public class CrudCapContext : DbContext
    {

        public CrudCapContext(DbContextOptions<CrudCapContext> options) : base(options)
        {
        }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Properties> Properties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudCapContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSave();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSave()
        {
            IEnumerable<EntityEntry> changedEntities = ChangeTracker.Entries();

            foreach (EntityEntry changedEntity in changedEntities)
            {
                if (changedEntity.State is EntityState.Detached or EntityState.Unchanged)
                {
                    continue;
                }

                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            if (entity.Id == Guid.Empty)
                            {
                                entity.Id = Guid.NewGuid();
                            }

                            entity.CreatedAt = DateTime.Now;
                            entity.LastUpdatedAt = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entity.LastUpdatedAt = DateTime.Now;

                            break;
                    }
                }
            }
        }
    }
}