using WebStore.DomainEntities.Entities.Base;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.Entities
{
    public class Section : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int OrderNumber { get; set; }
    }
}
