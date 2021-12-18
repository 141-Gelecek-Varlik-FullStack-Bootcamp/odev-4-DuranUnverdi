using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patikahafta4.Infrastructure
{
    public class LoginFilter : Attribute, IActionFilter
    {
        private readonly IMemoryCache _memoryCache;
        const string cacheKey = "userKey";
        public LoginFilter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
              if (!_memoryCache.TryGetValue(cacheKey, out User response))
            {
                context.Result = new BadRequestObjectResult("Sign In");
            }
            return;
        }
    }
}
