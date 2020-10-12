using App.Core.Abstract;
using App.Data;
using App.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Concrete
{
    public class ProductService : Service<Products>, IProductService
    {
        public ProductService(DataContext context) : base(context)
        {
        }

        public async Task<List<Products>> GetProductsWithCategories(int id)
        {
            return await _context.Products.Where(x => x.Id == id).Include(x => x.Categories).ToListAsync();
        }
    }
}
