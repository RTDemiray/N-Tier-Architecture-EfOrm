using App.Core.Abstract;
using App.Data;
using App.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Concrete
{
    public class CategoryService : Service<Categories>, ICategoryService
    {
        public CategoryService(DataContext context) : base(context)
        {
        }

        public async Task<List<Categories>> GetCategoriesWithProducts(int Id)
        {
            return await _context.Categories.Where(x => x.Id == Id).Include(x => x.Products).ToListAsync();
        }
    }
}
