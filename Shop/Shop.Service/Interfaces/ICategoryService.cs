using Shop.Service.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryGetDto> PostAsync(CategoryPostDto categoryPostDto);
        Task PutAsync(int? id, CategoryPutDto categoryPutDto);
        Task<List<CategoryListDto>> GetList();
        Task<CategoryGetDto> Get(int? id);
    }
}
