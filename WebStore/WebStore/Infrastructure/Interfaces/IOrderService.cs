using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainEntities.Entities;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetUserOrders(string UserName);

        Order GetOrderById(int id);

        Order CreateOrder(OrderViewModel OrderModel, CartViewModel CartModel, string UserName);
    }
}
