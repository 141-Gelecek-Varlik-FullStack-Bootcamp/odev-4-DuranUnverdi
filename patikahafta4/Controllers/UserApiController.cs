using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patikahafta4.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odev4.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        // private readonly UserManager _userManager;
        //public UserController(UserManager userManager)
        //{
        //    _userManager = userManager;
        //}
       private readonly IUserService _userService;
        private readonly MailJob _mailJobs;
        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        public UserApiController(IUserService userService, MailJob mailJobs) : this(userService)
        {
            _mailJobs = mailJobs;
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] User user)
        {
           _userService.TAdd(user);
            BackgroundJob.Schedule(() => _mailJobs.SendWelcomeMail(user.UserName, user.UserMail), TimeSpan.FromSeconds(15));
            return  Ok();
        }
        [HttpGet]
        public List<User> GetUser()
        {
            return _userService.GetList();
       
        }
        [HttpGet]
        public User Edit(int id)
        {

            var userDb = _userService.TGetById(id);

            return userDb;

        }
        [HttpPost]
        public User Edit(User user)
        {
            _userService.TUpdate(user);
            return user;
        }

    }
}
