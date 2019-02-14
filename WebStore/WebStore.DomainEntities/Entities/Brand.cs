using System.Collections.Generic;
using WebStore.DomainEntities.Entities.Base;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set ; }
        /// <summary>
        /// Один-ко-многим
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
