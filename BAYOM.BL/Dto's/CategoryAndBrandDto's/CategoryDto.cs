using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Dto_s.CategoryAndBrandDto_s
{
	public class CategoryDto
	{
		public int Categoryid { get; set; }

		public string? Categoryname { get; set; }

		public byte? Topcategoryid { get; set; }
	}
}
