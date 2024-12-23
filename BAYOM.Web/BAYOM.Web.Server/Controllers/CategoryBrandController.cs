using AutoMapper;
using BAYOM.BL.Abstract;
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
		public CategoryBrandController(IServices<Productbrand> productBrand, IServices<Topcategory> topCategory, ICategorySercive categorySercive)
		{
			_serviceBrand = productBrand;
			_serviceTopCategory = topCategory;
			_categorySercive = categorySercive;
		}

		[HttpGet("ProductBrand", Name = "GetAllBrand")]
		public async Task<ActionResult<IEnumerable<Productbrand>>> GetAllBrand()
		{
			var brand = await _serviceBrand.GetAllAsync();
			if (brand == null)
			{
				return NotFound();
			}
			return Ok(brand);
		}
		[HttpGet("TopCategory", Name = "GetAllTopCategory")]
		public async Task<ActionResult<IEnumerable<Topcategory>>> GetAllTopCategory()
		{
			var topCategory = await _serviceTopCategory.GetAllAsync();
			if (topCategory == null)
			{
				return NotFound();
			}
			return Ok(topCategory);
		}

		[HttpPost("TopCategory")]
		public async Task<ActionResult<IEnumerable<Category>>> GetCategory(int id)
		{
			var category = await _categorySercive.GetCategory(id);
			if (category == null)
			{
				return Unauthorized("İlgili Category Bulunamadı");
			}
			return Ok(category);
		}
	}
}
