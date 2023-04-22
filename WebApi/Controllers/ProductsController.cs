using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _productRepository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{articleNumber}")]
        public async Task<IActionResult> Get(int articleNumber)
        {
            var product = await _productRepository.GetAsync(articleNumber);
            if(product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpGet("tag/{tagName}")]
        public async Task<IActionResult> GetByTag(string tagName)
        {
            return Ok(await _productRepository.GetAllByTagAsync(tagName));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreateProduct(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                return Created("", await _productRepository.AddAsync(model));
            }
            return BadRequest(ModelState);
        }
    }
}
