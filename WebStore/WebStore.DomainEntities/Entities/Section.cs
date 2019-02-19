using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainEntities.Entities.Base;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int OrderNumber { get; set; }
        [ForeignKey("ParentId")]
        public virtual Section ParentSection { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
