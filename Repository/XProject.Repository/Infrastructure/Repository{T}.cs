using Invedia.Data.EF.Interfaces.DbContext;
using Invedia.Data.EF.Services.Repository;
using XProject.Contract.Repository.Models;
using XProject.Core.Utils;

namespace XProject.Repository.Infrastructure
{
    public abstract class Repository<T> : EntityStringRepository<T> where T : Entity, new()
    {
        protected string ConnectionString;

        //private readonly SqlGeneratorConfig _config = new SqlGeneratorConfig { SqlProvider = SqlProvider.Oracle };
        protected Repository(IDbContext dbContext) : base(dbContext)
        {
            ConnectionString = SystemHelper.AppDb;
        }
    }
}