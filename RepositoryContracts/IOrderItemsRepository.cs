using Entities;

namespace RepositoryContracts
{
    public interface IOrderItemsRepository
    {
        /// <summary>
        /// Adds an order item to the repository
        /// </summary>
        /// <param name="orderItem">Order item to add</param>
        /// <returns>Added order item</returns>
        Task<OrderItem> AddOrderItem(OrderItem orderItem);


        /// <summary>
        /// Deletes an order item from the repository based on its order item id
        /// </summary>
        /// <param name="orderItemId">Id of order item to delete</param>
        /// <returns>a boolean indicating whether the deletion was successful</returns>
        Task<bool> DeleteOrderItemByOrderItemId(Guid orderItemId);


        /// <summary>
        /// Retrieves all order items from the repository
        /// </summary>
        /// <returns></returns>
        Task<List<OrderItem>> GetAllOrderItems();


        /// <summary>
        /// Retrieves the order items associated with a specific order id from the repository
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <returns>A list of order items associated with the order ID</returns>
        Task<List<OrderItem>> GetOrderItemsByOrderId(Guid orderId);


        /// <summary>
        /// Retrieves an order item from the repository based on order item id
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns>order item if id matches, else null</returns>
        Task<OrderItem?> GetOrderItemByOrderItemId(Guid orderItemId);


        /// <summary>
        /// Updates an order item in the repository
        /// </summary>
        /// <param name="orderItem"></param>
        /// <returns>The updated order item</returns>
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
    }
}