using System.Threading;
using System.Threading.Tasks;

namespace XProject.Contract.Service.Base
{
    public interface ICreateable<in T, TKey> where T : class, new()
    {
        Task<TKey> CreateAsync(T model, CancellationToken cancellationToken = default);
    }
}