using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Orders
{
    /// <summary>
    /// Service for adding orders
    /// </summary>
    public interface IOrdersAdderService
    {
        /// <summary>
        /// Adds a new order.
        /// </summary>
        /// <param name="orderRequest">The order details.</param>
        /// <returns>The added order.</returns>
        Task<OrderResponse> AddOrder(OrderAddRequest orderAddRequest);
    }
}
