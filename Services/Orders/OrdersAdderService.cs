using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    /// <summary>
    /// Service for adding orders
    /// </summary>
    public class OrdersAdderService : IOrdersAdderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrdersAdderService> _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersAdderService"/> class
        /// </summary>
        /// <param name="ordersRepository"></param>
        /// <param name="orderItemsRepository"></param>
        /// <param name="logger"></param>
        public OrdersAdderService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository, ILogger<OrdersAdderService> logger)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        ///<inheritdoc/>
        public async Task<OrderResponse> AddOrder(OrderAddRequest orderAddRequest)
        {
            _logger.LogInformation("Adding a new order");

            // Create a new order entity and generate a unique OrderId
            var order = orderAddRequest.ToOrder();
            order.OrderId = Guid.NewGuid();

            // Add the order to the repository
            var addedOrder = await _ordersRepository.AddOrder(order);
            var addedOrderResponse = addedOrder.ToOrderResponse();

            // Add the order items to the repository and associate them with the order
            foreach (var item in orderAddRequest.OrderItems)
            {
                var orderItem = item.ToOrderItem();
                orderItem.OrderItemId = Guid.NewGuid();
                orderItem.OrderId = addedOrder.OrderId;

                var addedOrderItem = await _orderItemsRepository.AddOrderItem(orderItem);
                addedOrderResponse.OrderItems.Add(addedOrderItem.ToOrderItemResponse());
            }

            _logger.LogInformation("Order added successfully");

            return addedOrderResponse;
        }
    }
}
