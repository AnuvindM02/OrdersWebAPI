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
    /// Service for updating orders
    /// </summary>
    public class OrdersUpdaterService : IOrdersUpdaterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersUpdaterService> _logger;


        /// <summary>
        /// Initializes an instance of <see cref="OrdersUpdaterService"/> class
        /// </summary>
        /// <param name="ordersRepository"></param>
        /// <param name="logger"></param>
        public OrdersUpdaterService(IOrdersRepository ordersRepository, ILogger<OrdersUpdaterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }


        public async Task<OrderResponse> UpdateOrder(OrderUpdateRequest orderUpdateRequest)
        {
            _logger.LogInformation($"Updating order with ID: {orderUpdateRequest.OrderId}");

            var order = orderUpdateRequest.ToOrder();
            var updatedOrder = await _ordersRepository.UpdateOrder(order);
            var updatedOrderResponse = updatedOrder.ToOrderResponse();

            _logger.LogInformation($"Order with ID {orderUpdateRequest.OrderId} updated successfully");

            return updatedOrderResponse;
        }
    }
}
