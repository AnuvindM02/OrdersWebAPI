using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.OrderItems
{
    /// <summary>
    /// Service contract for updating order items
    /// </summary>
    public interface IOrderItemsUpdaterService
    {
        /// <summary>
        /// Updates an order item.
        /// </summary>
        /// <param name="orderItemRequest">The request containing the updated order item data.</param>
        /// <returns>The updated order item.</returns>
        Task<OrderItemResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest);
    }
}
