using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Orders
{
    /// <summary>
    /// Service for retrieving orders
    /// </summary>
    public interface IOrdersGetterService
    {
        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A list of orders.</returns>
        Task<List<OrderResponse>> GetAllOrders();

        /// <summary>
        /// Retrieves an order by its ID.
        /// </summary>
        /// <param name="orderId">The ID of the order to retrieve.</param>
        /// <returns>The retrieved order, or null if not found.</returns>
        Task<OrderResponse?> GetOrderByOrderId(Guid orderId);
    }
}
