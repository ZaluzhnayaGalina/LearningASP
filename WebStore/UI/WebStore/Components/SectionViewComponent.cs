using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Components
{
    public class SectionViewComponent : ViewComponent
    {
        private readonly IProductData _productData;
        public SectionViewComponent(IProductData productData)
        {
            _productData = productData;
        }


        public async Task<IViewComponentResult> InvokeAsync()

        {
            return View(GetSections());
        }
        private List<SectionViewModel> GetSections()
        {
            var categories = _productData.GetSections();
            var parentCategories = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentSections = new List<SectionViewModel>();
            foreach (var parentCategory in parentCategories)
            {
                parentSections.Add(new SectionViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    OrderNumber = parentCategory.OrderNumber,
                    Parent = null
                });
            }
            foreach (var sectionViewModel in parentSections)
            {
                var childCategories = categories.Where(c => c.ParentId.Equals(sectionViewModel.Id));
                foreach (var childCategory in childCategories)
                {
                    sectionViewModel.Children.Add(new SectionViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        OrderNumber = childCategory.OrderNumber,
                        Parent = sectionViewModel
                    });
                }
                sectionViewModel.Children = sectionViewModel.Children.OrderBy(c => c.OrderNumber).ToList();
            }
            parentSections = parentSections.OrderBy(c => c.OrderNumber).ToList();
            return parentSections;
        }

    }
}

