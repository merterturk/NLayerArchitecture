using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        public IActionResult Create()
        {
            var category = _categoryService.GetAllAsync().Result;
            ViewBag.Category = new SelectList(_mapper.Map<IEnumerable<CategoryDto>>(category),"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var category = _categoryService.GetAllAsync().Result;
            ViewBag.Category = new SelectList(_mapper.Map<IEnumerable<CategoryDto>>(category), "Id", "Name");
            return View(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(ProductNotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var category = _productService.GetByIdAsync(id).Result;
            _productService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
