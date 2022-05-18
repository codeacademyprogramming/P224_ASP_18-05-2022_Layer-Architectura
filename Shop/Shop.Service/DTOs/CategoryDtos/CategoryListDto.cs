using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.DTOs.CategoryDtos
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Name { get; set; }
    }

    public class CategoryListDtoValidator : AbstractValidator<CategoryListDto>
    {
        public CategoryListDtoValidator()
        {

        }
    }
}
