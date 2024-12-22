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
		private readonly IServices<Product> _service;
		private readonly IMapper _mapper;
		public ProductsController(IProductService productService, IServices<Product> service,IMapper mapper)
		{
			_productService = productService;
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<ProductDto>> GetLastestProduct()
		{
			var products= await _productService.GetProductsLastestAsync();
			var productsDto =_mapper.Map<IEnumerable<ProductDto>>(products);
			return productsDto;
		}
	}
}
