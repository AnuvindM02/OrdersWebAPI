using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Orders
{
    /// <summary>
    /// Service for updating orders
    /// </summary>
    public interface IOrdersUpdaterService
    {
        /// <summary>
        /// Updates an existing order.
        /// </summary>
        /// <param name="orderRequest">The updated order details.</param>
        /// <returns>The updated order.</returns>
        Task<OrderResponse> UpdateOrder(OrderUpdateRequest orderUpdateRequest);
    }
}
