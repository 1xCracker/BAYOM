using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Abstract
{
	public interface ICategorySercive
	{
		Task<IEnumerable<Category>> GetCategory(int id);
	}
}
