using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainEntities.Entities.Base.Interfaces;

namespace WebStore.DomainEntities.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public int OrderNumber { get; set; }
    }
}
