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
		public ProductsController(IProductService productService, IServices<Product> service,IMapper mapper)
		{
			_productService = productService;
			_serviceProduct = service;
			_mapper = mapper;
		}

		[HttpGet("latest", Name ="GetLastestProducts")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetLastestProduct()
		{
			var products= await _productService.GetProductsLastestAsync();
			if (products == null)
			{
				return NotFound();
			}
			var productsDto =_mapper.Map<IEnumerable<ProductDto>>(products);
			if (productsDto == null)
			{
				return NotFound();
			}
			return Ok(productsDto);
		}
		[HttpGet("all",Name ="GetAllProducts")]
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

	}
}
