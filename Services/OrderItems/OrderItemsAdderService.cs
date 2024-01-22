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
    /// Service class for adding order items
    /// </summary>
    public class OrderItemsAdderService : IOrderItemsAdderService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsAdderService> _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemsAdderService"/> class
        /// </summary>
        /// <param name="orderItemsRepository"></param>
        /// <param name="logger"></param>
        public OrderItemsAdderService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsAdderService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        ///<inheritdoc/>
        public async Task<OrderItemResponse> AddOrderItem(OrderItemAddRequest orderItemAddRequest)
        {
            _logger.LogInformation("Adding order item...");

            // Convert the request DTO to an OrderItem entity
            var orderItem = orderItemAddRequest.ToOrderItem();

            // Generate a new OrderItemId
            orderItem.OrderItemId = Guid.NewGuid();

            // Add the order item to the repository
            var addedOrderItem = await _orderItemsRepository.AddOrderItem(orderItem);

            _logger.LogInformation($"Order item added successfully. Order Item ID: {addedOrderItem.OrderItemId}.");

            // Convert the added order item to a response DTO
            return addedOrderItem.ToOrderItemResponse();
        }
    }
}
