using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Newtonsoft.Json;
using patikahafta4.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patikahafta4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [ServiceFilter(typeof(LoginFilter))]
        public Product Insert([FromBody] Product product)
        {
            _productService.TAdd(product);
            return product;
        }
        [HttpGet]
        public List<Product> GetProduct()
        {
            return _productService.GetList(x => x.ProductStatus == true);
        }
        [HttpGet]
        public Product GetByProduct(int id)
        {

            var userDb = _productService.TGetById(id);

            return userDb;

        }
        [HttpPost]
        public Product Edit([FromBody] Product product)
        {
            _productService.TUpdate(product);
            return product;
        }

        //[HttpPut("{id}")]
        //public Product Update([FromBody] Product product, int id)
        //{
        //    _productService.TGetById(id);
        //    _productService.TUpdate(product);
        //    return product;
        //}
        [HttpPost]
        public Product Delete(Product product)
        {
            product.ProductStatus = false;
            _productService.TUpdate(product);
            return product;
        }
        [HttpGet]
        public IActionResult GetProductPage([FromQuery] PaginationFilter filter)
        {
            var list = _productService.GetList(x => x.ProductStatus == true);
            return Ok(_productService.GetPaged(filter.PageNumber, filter.PageSize, list));
        }
        [HttpGet]
        public IActionResult GetFiltered([FromQuery] Product product)
        {//controller içinde sadece basit kontrolü yaptım.
            //var list = _productService.GetList(x => x.ProductStatus == true);
            var proc = _productService.GetList(y => y.ProductName =="Tencere");
            if (proc ==null)
            {
                return BadRequest("Invalid values.");
            }
            return Ok(proc);
        }
    }
}
