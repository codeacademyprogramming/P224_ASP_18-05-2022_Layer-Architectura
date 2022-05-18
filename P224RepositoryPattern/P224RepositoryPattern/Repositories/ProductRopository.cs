using P224RepositoryPattern.Data.DAL;
using P224RepositoryPattern.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224RepositoryPattern.Repositories
{
    public class ProductRopository :Repository<Product>, IProductRopository
    {
        public ProductRopository(AppDbContext context) : base(context)
        {

        }
    }
}
