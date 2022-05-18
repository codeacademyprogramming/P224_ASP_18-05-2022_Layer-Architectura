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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.CommitAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryRepository.GetAllAsync(s=>!s.IsDeleted));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _categoryRepository.GetAsync(s => !s.IsDeleted && s.Id == id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int? id, Category category)
        {
            Category existed = await _categoryRepository.GetAsync(s => !s.IsDeleted && s.Id == id);
            existed.Name = category.Name;
            await _categoryRepository.CommitAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            Category existed = await _categoryRepository.GetAsync(s => !s.IsDeleted && s.Id == id);
            _categoryRepository.Remove(existed);
            await _categoryRepository.CommitAsync();

            return NoContent();
        }
    }
}
