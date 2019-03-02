using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Interfaces;
using WebStore.Models;
using System.Linq;
namespace WebStore.Components
{
    public class BrandViewComponent: ViewComponent
    {
        private readonly IProductData _productData;
        public BrandViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(GetBrands());
        }
        private List<BrandViewModel> GetBrands()
        {
            var res = new List<BrandViewModel>();
            var brands = _productData.GetBrands();
            foreach(var b in brands)
            {
                res.Add(new BrandViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    OrderNumber = b.OrderNumber,
                });
            }
            return res.OrderBy(b => b.OrderNumber).ToList();
        }
    }
}
