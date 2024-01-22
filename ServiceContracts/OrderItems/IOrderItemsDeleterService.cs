using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.OrderItems
{
    /// <summary>
    /// Service contract for deleting order items
    /// </summary>
    public interface IOrderItemsDeleterService
    {
        /// <summary>
        /// Deletes an order item based on its order item ID.
        /// </summary>
        /// <param name="orderItemId">The ID of the order item to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteOrderItemByOrderItemId(Guid orderItemId);
    }
}
