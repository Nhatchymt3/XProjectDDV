using Invedia.Data.EF.Models;
using System;
using XProject.Core.Utils;

namespace XProject.Contract.Repository.Models
{
    public abstract class Entity : StringEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString("N");

            CreatedTime = LastUpdatedTime = CoreHelper.SystemTimeNow;
        }
    }
}