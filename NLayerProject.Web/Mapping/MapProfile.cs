using AutoMapper;
using NLayerProject.Core.Models;
using NLayerProject.Web.DTOs;


namespace NLayerProject.Web.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
 
            CreateMap<Category, CategoryWithProductDto>().ReverseMap();
 
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
        }
    }
}
