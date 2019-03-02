using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.ViewModels
{
    public class SectionViewModel: INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public List<SectionViewModel> Children { get; set; } = new List<SectionViewModel>();
        public SectionViewModel Parent { get; set; }
    }
}
