﻿using Entities;
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
    /// Service for retrieving filtered orders
    /// </summary>
    public class OrdersFilterService : IOrdersFilterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersFilterService> _logger;


        /// <summary>
        /// Initializes an instance of <see cref="OrdersFilterService"/> class
        /// </summary>
        /// <param name="ordersRepository"></param>
        /// <param name="logger"></param>
        public OrdersFilterService(IOrdersRepository ordersRepository, ILogger<OrdersFilterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }


        ///<inheritdoc/>
        public async Task<List<OrderResponse>> GetFilteredOrders(string searchBy, string? searchString)
        {
            _logger.LogInformation($"Filtering orders by {searchBy}: {searchString}");

            List<Order> filteredOrders;
            switch (searchBy)
            {
                case nameof(OrderResponse.CustomerName):
                    // Filter orders by customer name
                    filteredOrders = await _ordersRepository.GetFilteredOrders(o => o.CustomerName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
                    break;
                case nameof(OrderResponse.OrderDate):
                    // Filter orders by order date
                    filteredOrders = await _ordersRepository.GetFilteredOrders(o => o.OrderDate.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase));
                    break;
                case nameof(OrderResponse.OrderNumber):
                    // Filter orders by order number
                    filteredOrders = await _ordersRepository.GetFilteredOrders(o => o.OrderNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    // Invalid search field, return an empty list
                    _logger.LogWarning($"Invalid search field: {searchBy}");
                    return new List<OrderResponse>();
            }

            var orderResponses = filteredOrders.ToOrderResponseList();

            _logger.LogInformation($"Filtered orders by {searchBy}: {searchString} retrieved successfully");

            return orderResponses;
        }
    }
}
