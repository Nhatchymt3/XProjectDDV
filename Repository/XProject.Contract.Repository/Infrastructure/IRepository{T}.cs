using Invedia.Data.EF.Interfaces.Repository;
using XProject.Contract.Repository.Models;

namespace XProject.Contract.Repository.Infrastructure
{
    public interface IRepository<T> : IStringEntityRepository<T> where T : Entity, new()
    {
    }
}