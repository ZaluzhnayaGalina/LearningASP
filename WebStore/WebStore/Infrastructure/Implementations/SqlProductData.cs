using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.DomainEntities.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductData : IProductData
    {
        private WebStoreContext _context;
        public SqlProductData(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.AsEnumerable();
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Section)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts(ProductFilter Filter)
        {
            if (Filter is null)
                return _context.Products
                    .Include(p=>p.Brand)
                    .Include(p=>p.Section)
                    .AsEnumerable();
            IQueryable<Product> result = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Section);
            if (Filter.BrandId != null)
                result = result.Where(x => x.BrandId == Filter.BrandId);
            if (Filter.SectionId != null)
                return _context.Products.Where(x => x.SectionId == Filter.SectionId);
            return result.AsEnumerable();
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.AsEnumerable();
        }
    }
}
