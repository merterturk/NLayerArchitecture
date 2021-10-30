﻿using NLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

        // bool ControlInnerBarcode(Product product);
    }
}
