using Invedia.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using XProject.Contract.Repository.Infrastructure;
using XProject.Contract.Service;

namespace XProject.Service
{
    [ScopedDependency(ServiceType = typeof(IBootstrapperService))]
    public class BootstrapperService : Base.Service, IBootstrapperService
    {
        private readonly IBootstrapper _bootstrapper;

        public BootstrapperService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _bootstrapper = serviceProvider.GetRequiredService<IBootstrapper>();
        }

        public async Task InitialAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.InitialAsync(cancellationToken);
        }

        public Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            _bootstrapper.RebuildAsync(cancellationToken).Wait(cancellationToken);

            return Task.CompletedTask;
        }
    }
}