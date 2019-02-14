﻿using System.Collections.Generic;
using WebStore.Data;
using WebStore.DomainEntities.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands()
        {
            return TestData.Brands;
        }

        public IEnumerable<Product> GetProducts(ProductFilter Filter)
        {
            IEnumerable<Product> products = TestData.Products;
            if (Filter is null || Filter.SectionId is null && Filter.BrandId is null)
                return products;

            if (Filter.SectionId != null)
                products = products.Where(product => product.SectionId == Filter.SectionId);
            if (Filter.BrandId != null)
                products = products.Where(product => product.SectionId == Filter.BrandId);
            return products;
        }

        public IEnumerable<Section> GetSections()
        {
            return TestData.Sections;
        }

        IEnumerable<Brand> IProductData.GetBrands()
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Section> IProductData.GetSections()
        {
            throw new System.NotImplementedException();
        }
    }
}
