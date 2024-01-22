using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.OrderItems
{
    /// <summary>
    /// Represents the service contract for adding order items
    /// </summary>
    public interface IOrderItemsAdderService
    {
        /// <summary>
        /// Adds an order item
        /// </summary>
        /// <param name="orderItemAddRequest"></param>
        /// <returns>The added order item</returns>
        Task<OrderItemResponse> AddOrderItem(OrderItemAddRequest orderItemAddRequest);
    }
}
