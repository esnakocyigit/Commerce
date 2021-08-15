using System;
using Commerce.Entity;
using Commerce.Services;
using Commerce.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]    
      
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetResult()
        {
            var products = _productService.GetList();
            return Ok(products);
        }

        [HttpGet("detail")] // Product/detail?id=1
        public IActionResult Detail(int id)
        {
            var product = _productService.Detail(id);
            return Ok(product);
        }

        [HttpGet("withparameter")] //* Get "action"ları 1'den fazla ise url unique olmalı.
        public IActionResult DetailWithBody([FromBody] ProductDetailRequestVM request) //*[FromBody] isteklerinde model gerekiyore
        {
            var user = _productService.Detail(request.Id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if(string.IsNullOrEmpty(product.Name))
                throw new Exception("Ürün ismi girilmeli");
            _productService.Add(product);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update([FromBody]Product product)
        {
            if(product.Id <= 0)
                throw new System.Exception("Geçersiz Id ürün güncellenemedi");
            if(product.Name.Length > 20)
                throw new System.Exception("İsim karakter uzunluğu 20 karakteri geçemez");

            _productService.Update(product);
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                throw new System.Exception("Geçersiz Id ürün güncellenemedi");

            _productService.Delete(id);
            return Ok();
        }
    }
}