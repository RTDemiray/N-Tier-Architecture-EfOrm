using App.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Abstract
{
    public interface ICategoryService : IService<Categories>
    {
        public Task<List<Categories>> GetCategoriesWithProducts(int id);
    }
}
