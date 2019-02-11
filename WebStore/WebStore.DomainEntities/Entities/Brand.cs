using WebStore.DomainEntities.Entities.Base;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int OrderNumber { get; set ; }
    }
}
