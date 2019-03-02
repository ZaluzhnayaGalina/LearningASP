using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.DomainEntities.Entities;
using WebStore.DomainEntities.Entities.Base;

namespace WebStore.DomainEntities
{
    public class OrderItem : BaseEntity
    {
        /// <summary>Заказ</summary>
        public virtual Order Order { get; set; }

        /// <summary>Товар в заказе</summary>
        public virtual Product Product { get; set; }

        /// <summary>Зена за элемент заказа</summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>Количество товаров</summary>
        public int Count { get; set; }
    }
}
