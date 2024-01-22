using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    /// <summary>
    /// Service for deleting orders
    /// </summary>
    public class OrdersDeleterService : IOrdersDeleterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersDeleterService> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="OrdersDeleterService"/> class
        /// </summary>
        /// <param name="ordersRepository"></param>
        /// <param name="logger"></param>
        public OrdersDeleterService(IOrdersRepository ordersRepository, ILogger<OrdersDeleterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }


        ///<inheritdoc/>
        public async Task<bool> DeleteOrderByOrderId(Guid orderId)
        {
            _logger.LogInformation($"Deleting order with ID: {orderId}");

            // Call the repository method to delete the order
            var isDeleted = await _ordersRepository.DeleteOrderByOrderId(orderId);

            if (isDeleted)
            {
                _logger.LogInformation($"Order with ID {orderId} deleted successfully");
            }
            else
            {
                _logger.LogWarning($"Order with ID {orderId} not found");
            }

            return isDeleted;
        }
    }
}
