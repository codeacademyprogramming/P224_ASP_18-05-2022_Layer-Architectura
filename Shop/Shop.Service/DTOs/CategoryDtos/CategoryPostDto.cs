using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.DTOs.CategoryDtos
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public IFormFile File { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Name Is Reuquered")
                .MaximumLength(25).WithMessage("Name Maximum Length Must Be 25 Symbol");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.IsMain && x.File == null)
                {
                    context.AddFailure(nameof(x.File), "File Is Reuquered");
                }
            });
        }
    }
}
