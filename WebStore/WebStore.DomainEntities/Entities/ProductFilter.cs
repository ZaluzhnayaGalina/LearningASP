using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainEntities.Entities
{
    public class ProductFilter
    {
        /// <summary>Секция товара</summary>
        public int? SectionId { get; set; }

        /// <summary>Бренд товара</summary>
        public int? BrandId { get; set; }
    }
}
