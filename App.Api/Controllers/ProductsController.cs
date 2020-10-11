using App.Core.Abstract;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IService<Products> _service;
        private readonly IProductService _productsService;

        public ProductsController(IService<Products> service, IProductService productsService)
        {
            _service = service;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.Table.ToListAsync());
        }

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetProductsWithCategories(int id)
        {
            return Ok(await _productsService.GetProductsWithCategories(id));
        }

    }
}
