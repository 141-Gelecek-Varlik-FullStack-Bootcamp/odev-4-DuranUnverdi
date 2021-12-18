using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odev4.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // private readonly UserManager _userManager;
        //public UserController(UserManager userManager)
        //{
        //    _userManager = userManager;
        //}
       private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public User Insert([FromBody] User user)
        {
            _userService.TAdd(user);
            return user;
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
