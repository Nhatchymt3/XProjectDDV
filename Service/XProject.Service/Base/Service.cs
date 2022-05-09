using Microsoft.Extensions.DependencyInjection;
using System;
using XProject.Contract.Repository.Infrastructure;

namespace XProject.Service.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected Service(IServiceProvider serviceProvider)
        {
            UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}