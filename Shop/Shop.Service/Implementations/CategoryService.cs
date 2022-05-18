using AutoMapper;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Service.DTOs.CategoryDtos;
using Shop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryGetDto> Get(int? id)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id, "Children", "Parent");

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task<List<CategoryListDto>> GetList()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync(c => !c.IsDeleted);

            List<CategoryListDto> categoryListDtos = _mapper.Map<List<CategoryListDto>>(categories);

            return categoryListDtos;
        }

        public async Task<CategoryGetDto> PostAsync(CategoryPostDto categoryPostDto)
        {
            Category category = _mapper.Map<Category>(categoryPostDto);

            await _categoryRepository.AddAsync(category);

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task PutAsync(int? id, CategoryPutDto categoryPutDto)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);

            category.Name = categoryPutDto.Name;
            category.IsMain = categoryPutDto.IsMain;
            category.ParentId = categoryPutDto.ParentId;

            await _categoryRepository.CommitAsync();
        }
    }
}
