using Invedia.Data.EF.Interfaces.DbContext;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XProject.Contract.Repository.Infrastructure;

namespace XProject.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IBootstrapper))]
    public class Bootstrapper : IBootstrapper
    {
        private readonly IDbContext _dbContext;

        public Bootstrapper(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task InitialAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.MigrateAsync(cancellationToken);
        }

        public Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}