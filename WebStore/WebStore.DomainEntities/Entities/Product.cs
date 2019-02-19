using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainEntities.Entities.Base;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.Entities
{
    public class Product: NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set; }
        /// <summary>Секция товара</summary>
         public int SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        ///  <summary>Бренд товара</summary>
         public int? BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }
        ///  <summary>Ссылка на картинку</summary>
         public string ImageUrl { get; set; }

        /// <summary>Цена</summary>
         public decimal Price { get; set; }
}
}
