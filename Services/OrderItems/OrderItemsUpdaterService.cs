using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderItems
{
    /// <summary>
    /// Service class for updating order item
    /// </summary>
    public class OrderItemsUpdaterService : IOrderItemsUpdaterService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsUpdaterService> _logger;

        public OrderItemsUpdaterService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsUpdaterService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }


        ///<inheritdoc/>
        public async Task<OrderItemResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            _logger.LogInformation($"Updating order item. Order Item ID: {orderItemUpdateRequest.OrderItemId}...");

            // Convert the update request to an OrderItem entity
            var orderItem = orderItemUpdateRequest.ToOrderItem();

            // Update the order item
            var updatedOrderItem = await _orderItemsRepository.UpdateOrderItem(orderItem);

            _logger.LogInformation($"Order item updated successfully. Order Item ID: {updatedOrderItem.OrderItemId}.");

            // Convert the updated order item to a response object
            return updatedOrderItem.ToOrderItemResponse();
        }
    }
}

