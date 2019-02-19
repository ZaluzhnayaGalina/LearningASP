using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainEntities.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Brand> GetBrands();
        IEnumerable<Section> GetSections();
        IEnumerable<Product> GetProducts(ProductFilter Filter);
        Product GetProductById(int id);
    }
}
