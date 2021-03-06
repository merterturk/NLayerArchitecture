using AutoMapper;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Mapping
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
