using Invedia.Core.ObjUtils;
using Invedia.Data.EF.Interfaces.DbContext;
using Invedia.Data.EF.Models;
using Invedia.Data.EF.Services.UnitOfWork;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XProject.Contract.Repository.Infrastructure;
using XProject.Core.Utils;

namespace XProject.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IUnitOfWork))]
    public class UnitOfWork : BaseEntityUnitOfWork, IUnitOfWork
    {
        //protected readonly IServiceProvider ServiceProvider;

        public UnitOfWork(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override void StandardizeEntities()
        {
            var listState = new List<EntityState>
            {
                EntityState.Added,
                EntityState.Modified,
                EntityState.Deleted
            };

            var listEntry = DbContext.ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && listState.Contains(x.State))
                .Select(x => x).ToList();

            var dateTimeNow = CoreHelper.SystemTimeNow;

            foreach (var entry in listEntry)
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        baseEntity.DeletedTime = null;

                        baseEntity.LastUpdatedTime = baseEntity.CreatedTime = dateTimeNow;
                    }
                    else
                    {
                        if (baseEntity.DeletedTime != null)
                            baseEntity.DeletedTime =
                                ObjHelper.ReplaceNullOrDefault(baseEntity.DeletedTime, dateTimeNow);
                        else
                            baseEntity.LastUpdatedTime = dateTimeNow;
                    }
                }

                if (!(entry.Entity is Entity entity)) continue;

                //TODO
                int? loggedInUserId = null;//LoggedInUser.Current?.Id;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = entity.LastUpdatedBy = entity.CreatedBy ?? loggedInUserId;
                }
                else
                {
                    if (entity.DeletedTime != null)
                        entity.DeletedBy ??= loggedInUserId;
                    else
                        entity.LastUpdatedBy ??= loggedInUserId;
                }
            }
        }

        #region Save

        public override int SaveChanges()
        {
            StandardizeEntities();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            StandardizeEntities();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            StandardizeEntities();

            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return result;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            StandardizeEntities();

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken).ConfigureAwait(true);

            return result;
        }

        #endregion Save
    }
}