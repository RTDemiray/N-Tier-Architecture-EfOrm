using App.Core.Abstract;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<Categories> _service;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IService<Categories> service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.Table.Include(x=>x.Products).ToListAsync());
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoriesWithProducts(int id)
        {
            return Ok(await _categoryService.GetCategoriesWithProducts(id));
        }
    }
}
