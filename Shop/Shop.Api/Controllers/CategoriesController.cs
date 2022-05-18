using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Repositories;
using Shop.Service.DTOs.CategoryDtos;
using Shop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryPostDto categoryPostDto)
        {
            CategoryGetDto categoryGetDto = await _categoryService.PostAsync(categoryPostDto);
            return Ok(categoryGetDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetList());
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _categoryService.Get(id));
        }
    }
}
