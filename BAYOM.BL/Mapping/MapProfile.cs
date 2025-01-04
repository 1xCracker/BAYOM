using AutoMapper;
using BAYOM.BL.Dto_s.CategoryAndBrandDto_s;
using BAYOM.BL.Dto_s.ProductDto_s;
using BAYOM.BL.Dto_s.UserDto_s;
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
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Productbrand,ProductBrandDto>().ReverseMap();
            CreateMap<Topcategory, TopCategoryDto>().ReverseMap();
            CreateMap<User ,UserSignUpDto>().ReverseMap();
            CreateMap<Customer, UserSignUpDto>().ReverseMap();
           
            
            
            
            
            
            
            CreateMap<Product, ProductWithNameDto>()
          .ForMember(dest => dest.Productid, opt => opt.MapFrom(src => src.Productid))
          .ForMember(dest => dest.Productname, opt => opt.MapFrom(src => src.Productname))
          .ForMember(dest => dest.ProductpriceB, opt => opt.MapFrom(src => src.ProductpriceB))
          .ForMember(dest => dest.ProductpriceS, opt => opt.MapFrom(src => src.ProductpriceS))
          .ForMember(dest => dest.Productimage, opt => opt.MapFrom(src => src.Productimage))
          .ForMember(dest => dest.Categoryid, opt => opt.MapFrom(src => src.Category.Categoryid))
          .ForMember(dest => dest.Categoryname, opt => opt.MapFrom(src => src.Category.Categoryname))
          .ForMember(dest => dest.Productbrandid, opt => opt.MapFrom(src => src.Productbrand.Productbrandid))
          .ForMember(dest => dest.Productbrandname, opt => opt.MapFrom(src => src.Productbrand.Productbrandname))
          .ForMember(dest => dest.Topcategoryid, opt => opt.MapFrom(src => src.Topcategory.Topcategoryid))
          .ForMember(dest => dest.Topcategoryname, opt => opt.MapFrom(src => src.Topcategory.Topcategoryname));
        }
        
    }
}
