﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Core.Services;
using NLayerProject.Web.ApiService;
using NLayerProject.Web.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Filters
{
    public class CategoryNotFoundFilter : ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;
        public CategoryNotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = Convert.ToInt32(context.ActionArguments.Values.FirstOrDefault());

            var category = await _categoryApiService.GetByIdAsync(id);
            if (category != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add($"id'si {id} olan kategori veritabanında bulunamadı");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
          
        }

    }
}
