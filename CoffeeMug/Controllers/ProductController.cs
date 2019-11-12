using CoffeeMug.ModelDto;
using CoffeeMug.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CoffeeMug.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        protected readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<ProductOutputModel> Get()
        {
            return _productService.GetAll();
        }
        [HttpGet("{id}")]
        public ProductOutputModel Get(Guid id)
        {
            return _productService.Get(id);
        }
        [HttpPost]
        public Guid Post([FromBody] ProductCreateInputModel model)
        {
            if (ModelState.IsValid)
            {
                return _productService.Add(model);
            }
            else
            {
                return default;
            }
        }
        [HttpPut]
        public bool Put([FromBody] ProductUpdateInputModel model)
        {
            if (ModelState.IsValid)
            {
                return _productService.Update(model);
            }
            else
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _productService.Delete(id);
        }
    }
}