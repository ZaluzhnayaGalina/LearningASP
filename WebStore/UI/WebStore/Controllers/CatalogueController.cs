using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CatalogueController : Controller
    {
        private IProductData _productData;
        public CatalogueController(IProductData productData)
        {
            _productData = productData;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Shop(int? sectionId, int? brandId)
        {
            var products = _productData.GetProducts(new DomainEntities.Entities.ProductFilter
            {
                BrandId = brandId,
                SectionId =sectionId
            });
            var model = new CatalogViewModel
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Order = p.OrderNumber,
                    Price = p.Price,
                    Brand = p.Brand?.Name ?? string.Empty
                }).OrderBy(p => p.Order).ToArray()
            };
            return View(model);
        }
        public IActionResult ProductDetails(int id)
        {
            var product = _productData.GetProductById(id);
            if (product is null)
                return NotFound();
            return View(new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Order = product.OrderNumber,
                Price = product.Price,
                Brand = product.Brand?.Name ?? string.Empty
            });
        }
    }
}