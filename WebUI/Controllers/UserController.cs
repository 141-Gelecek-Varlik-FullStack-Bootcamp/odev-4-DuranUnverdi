using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/[controller]/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/[controller]/Login")]
        public IActionResult Login([FromForm] User user)
        {
            using (var client = new HttpClient())
            {
                var content = JsonContent.Create(user);
                var postTask = client.PostAsync("https://localhost:44399/api/Login/Login", content);          
                postTask.Wait();
                var response = postTask.Result;             
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("InsertProduct", "Product");
                }
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost("/[controller]/InsertUser")]
        public IActionResult InsertUser([FromForm] User user)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("https://localhost:44399/api/UserApi/InsertUser", content); 
                postTask.Wait();
                var response = postTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "User");
                }
            }

            return RedirectToAction("");
        }
    }
}
