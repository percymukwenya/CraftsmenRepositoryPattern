using Craftsmen.Domain.Entities;
using Craftsmen.Domain.Interfaces;
using Craftsmen.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftsmen.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
