using AutoMapper;
using BAYOM.BL.Dto_s.ProductDto_s;
using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile() { 
         CreateMap<Product,ProductDto>().ReverseMap();
        }
        
    }
}
