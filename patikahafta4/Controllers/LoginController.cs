using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patikahafta4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserService _userService;

        const string cacheKey = "userKey";
        public LoginController(IMemoryCache memoryCache, IUserService userService)
        {
            _memoryCache = memoryCache;
            _userService = userService;
          
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var dataValue = _userService.TGetByFilter(x => x.UserMail == user.UserMail && x.UserPassword == user.UserPassword);
            if (dataValue != null)
            {
                if (!_memoryCache.TryGetValue(cacheKey, out dataValue))
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        Priority = CacheItemPriority.Normal
                    };
                    _memoryCache.Set(cacheKey, dataValue, cacheOptions);
                    //_currentUser.SetCurrentUser(model.Entity)  
                }    
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
