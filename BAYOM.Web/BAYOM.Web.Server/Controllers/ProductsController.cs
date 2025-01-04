using AutoMapper;
using BAYOM.BL.Abstract;
using BAYOM.BL.Dto_s.ProductDto_s;
using BAYOM.EL.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYOM.Web.Server.Controllers
{


	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IServices<Product> _serviceProduct;
		private readonly IMapper _mapper;
		public ProductsController(IProductService productService, IServices<Product> service, IMapper mapper)
		{
			_productService = productService;
			_serviceProduct = service;
			_mapper = mapper;
		}

		[HttpGet("latest", Name = "GetLastestProducts")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetLastestProduct()
		{
			var products = await _productService.GetProductsLastestAsync();
			if (products == null)
			{
				return NotFound();
			}
			var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
			if (productsDto == null)
			{
				return NotFound();
			}
			return Ok(productsDto);
		}
		[HttpGet("all", Name = "GetAllProducts")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct()
		{
			var product = await _serviceProduct.GetAllAsync();
			if (product == null)
			{
				return NotFound();
			}
			var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);
			if (productDto == null)
			{
				return NotFound();
			}
			return Ok(productDto);
		}

		[HttpGet("GetProduct")]

		public async Task<ActionResult> GetProduct(int id)
		{
			if(id== null)
			{
				return BadRequest();
			}
			var product = await _serviceProduct.GetById(id);
			if(product == null)
			{
				return NotFound();
			}
			return Ok(product);
			
		}
		[HttpGet("GetAllProductWithName")]
		public async Task<ActionResult<IEnumerable<ProductWithNameDto>>> GetAllProductWithName()
		{
			var product =await _productService.GetProductWithName();
			var productmap = _mapper.Map<IEnumerable<ProductWithNameDto>>(product);
			return Ok(productmap);
		}
		
		[HttpPost("addProduct")]
		public async Task<ActionResult> AddProduct([FromForm] ProductDto productDto)
		{
			if (productDto == null)
			{
                return BadRequest("Geçersiz istek.");
            }
			var product = _mapper.Map<Product>(productDto);
			var post = await _serviceProduct.AddAsync(product);
			if (!post) {
                return StatusCode(500, "Sunucuda beklenmeyen bir hata oluştu.");
            }
			return CreatedAtAction(nameof(GetProduct),new {id = product.Productid,product});
         }
        [HttpPut("updateProduct{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductDto productDto)
        {
			if(id != productDto.Productid)
			{
				return BadRequest();
			}
			var productAny = await _productService.AnyAsync(id);
			if (!productAny)
			{
				return NotFound();
			}
            var product = _mapper.Map<Product>(productDto);
            var post = await _serviceProduct.UpdateAsync(product);
            if (!post)
            {
                return StatusCode(500, "Sunucuda beklenmeyen bir hata oluştu.");
            }
            return NoContent();
        }
		[HttpDelete("DeleteProduct")]
		public async Task<ActionResult> DeleteProduct(int id)
		{
			var response =await _productService.RemoveByIdAsync(id);
			if (!response)
			{
				return NotFound();
			}
			return Ok(response);
		}
			 

    }
}
