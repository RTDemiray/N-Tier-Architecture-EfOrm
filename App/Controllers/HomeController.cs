using System.Linq;
using System.Threading.Tasks;
using App.Core.Abstract;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Products> _productsServices;
        private readonly IProductService _productsService;
        private readonly IService<Categories> _categoriesServices;
        private readonly ICategoryService _categoryService;

        public HomeController(IService<Products> productsServices, IProductService productsService, IService<Categories> categoriesServices, ICategoryService categoryService)
        {
            _productsServices = productsServices;
            _productsService = productsService;
            _categoriesServices = categoriesServices;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesWithProducts = await _categoryService.GetCategoriesWithProducts(1);
            var categories = await _categoriesServices.Table.ToListAsync();
            
            var productsWithCategories = await _productsService.GetProductsWithCategories(1);
            var products = await _productsServices.Table.ToListAsync();
            return View();
        }
    }
}
