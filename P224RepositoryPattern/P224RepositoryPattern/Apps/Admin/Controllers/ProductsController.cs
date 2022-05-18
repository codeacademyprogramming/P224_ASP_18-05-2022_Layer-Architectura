using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P224RepositoryPattern.Data.Entities;
using P224RepositoryPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224RepositoryPattern.Apps.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRopository _productRopository;

        public ProductsController(IProductRopository productRopository)
        {
            _productRopository = productRopository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _productRopository.AddAsync(product);
            await _productRopository.CommitAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRopository.GetAllAsync(p=>!p.IsDeleted));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _productRopository.GetAsync(p => p.Id == id && !p.IsDeleted));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int? id, Product category)
        {
            Product existed = await _productRopository.GetAsync(p => p.Id == id && !p.IsDeleted);
            existed.Title = category.Title;
            await _productRopository.CommitAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            Product existed = await _productRopository.GetAsync(p => p.Id == id && !p.IsDeleted);
            _productRopository.Remove(existed);
            await _productRopository.CommitAsync();

            return NoContent();
        }
    }
}
