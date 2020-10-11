using App.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Abstract
{
    public interface IProductService : IService<Products>
    {
        public Task<List<Products>> GetProductsWithCategories(int id);
    }
}
