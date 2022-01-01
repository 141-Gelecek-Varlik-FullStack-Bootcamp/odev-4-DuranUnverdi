using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsertProduct()
        {
            return View();
        }
        [HttpPost("/[controller]/InsertProduct")]
        public IActionResult InsertProduct([FromForm] Product product)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("https://localhost:44399/api/ProductApi/InsertProduct", content);
                postTask.Wait();
                var response = postTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetProduct", "Product");
                }
            }

            return RedirectToAction("");
        }
        [HttpGet("/[controller]/GetProduct")]
        public IActionResult GetProduct([FromForm] List<Product> products=null)
        {

            using (var client = new HttpClient())
            {
                var responseMessage = client.GetAsync("https://localhost:44399/api/ProductApi/GetProduct");
                //List<Product> products = null;
                responseMessage.Wait();
                var response = responseMessage.Result;
                if (response.IsSuccessStatusCode)
                {
                    products = Newtonsoft.Json.JsonConvert.DeserializeObject <List<Product>>(response.Content.ReadAsStringAsync().Result);

                }
              
            }
            return View(products);

        }
    }
}
