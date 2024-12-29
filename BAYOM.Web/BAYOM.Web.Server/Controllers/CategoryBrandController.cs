using AutoMapper;
using BAYOM.BL.Abstract;
using BAYOM.BL.Dto_s.CategoryAndBrandDto_s;
using BAYOM.BL.Services;
using BAYOM.EL.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYOM.Web.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryBrandController : ControllerBase
	{
		private readonly IServices<Productbrand> _serviceBrand;
		private readonly IServices<Topcategory> _serviceTopCategory;
		private readonly ICategorySercive _categorySercive;
		private readonly IMapper _mapper;
		public CategoryBrandController(IServices<Productbrand> productBrand, IServices<Topcategory> topCategory, ICategorySercive categorySercive, IMapper mapper)
		{
			_serviceBrand = productBrand;
			_serviceTopCategory = topCategory;
			_categorySercive = categorySercive;
			_mapper = mapper;
		}

		[HttpGet("ProductBrand", Name = "GetAllBrand")]
		public async Task<ActionResult<IEnumerable<ProductBrandDto>>> GetAllBrand()
		{
			var brand = await _serviceBrand.GetAllAsync();
			if (brand == null)
			{
				return NotFound();
			}
			var brandDto =_mapper.Map<IEnumerable<ProductBrandDto>>(brand);
			if (brandDto == null)
			{
				return NotFound();	
			}
			return Ok(brandDto);
		}
		[HttpGet("TopCategory", Name = "GetAllTopCategory")]
		public async Task<ActionResult<IEnumerable<TopCategoryDto>>> GetAllTopCategory()
		{
			var topCategory = await _serviceTopCategory.GetAllAsync();
			if (topCategory == null)
			{
				return NotFound();
			}
			var topCategoryDto = _mapper.Map<IEnumerable<TopCategoryDto>>(topCategory);
			if (topCategoryDto == null)
			{
				return NotFound();
			}
			return Ok(topCategoryDto);
		}

		[HttpPost("TopCategory")]
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategory( int id)
		{
			var category = await _categorySercive.GetCategory(id);
			if (category == null)
			{
				return Unauthorized("İlgili Category Bulunamadı");
			}
			var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(category);
			if (categoryDto == null)
			{
				return Unauthorized("Mapleme işlemi başarısız");
			}
			return Ok(categoryDto);
		}
	}
}
