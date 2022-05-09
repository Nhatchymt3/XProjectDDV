using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using XProject.Core.Exceptions;

namespace XProject.Core.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                throw new BadRequestException(context
                    .ModelState
                    .Select(m => new KeyValuePair<string, ICollection<string>>(m.Key, m.Value.Errors.Select(e => e.ErrorMessage).ToList())).ToList());
        }
    }
}