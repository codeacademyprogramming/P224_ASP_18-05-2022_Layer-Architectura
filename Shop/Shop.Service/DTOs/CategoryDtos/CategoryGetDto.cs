using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.DTOs.CategoryDtos
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Nullable<int> ParentId { get; set; }

        public CategoryGetDto Parent { get; set; }
        public IEnumerable<CategoryGetDto> Children { get; set; }

    }
}
