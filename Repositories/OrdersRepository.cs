using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System.Linq.Expressions;


namespace Repositories
{
    /// <summary>
    /// Repository implmentation of managing orders
    /// </summary>
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OrdersRepository> _logger;

        public OrdersRepository(ApplicationDbContext db, ILogger<OrdersRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        ///<inheritdoc/>
        public async Task<Order> AddOrder(Order order)
        {
            _logger.LogInformation("OrdersRepository {Method name}: Adding order to the database",nameof(AddOrder));

            //Add the new order to the database context
            _db.Orders.Add(order);

            //Save changes to the database
            await _db.SaveChangesAsync();

            _logger.LogInformation("Order added successfully");

            return order;
        }

        ///<inheritdoc/>
        public async Task<bool> DeleteOrderByOrderId(Guid orderId)
        {
            _logger.LogInformation("OrdersRepository {Method name}: Deleting order with ID: {orderID}", nameof(DeleteOrderByOrderId),orderId);

            //Find the order with the specified ID
            var order = await _db.Orders.FindAsync(orderId);
            if(order == null)
            {
                _logger.LogWarning($"Order not found with ID:{orderId}");
                return false;
            }

            //Remove order from the database context
            _db.Orders.Remove(order);

            //Save changes to the database
            await _db.SaveChangesAsync();

            return true;
        }

        ///<inheritdoc/>
        public async Task<List<Order>> GetAllOrders()
        {
            _logger.LogInformation("OrdersRepository {Method name}: Retrieving orders", nameof(GetAllOrders));

            //Retrieve all orders in descending order by order date
            var order = await _db.Orders.OrderByDescending(x => x.OrderDate).ToListAsync();

            _logger.LogInformation($"Retrieved {order.Count} orders successfully.");

            return order;
        }

        ///<inheritdoc/>
        public async Task<List<Order>> GetFilteredOrders(Expression<Func<Order, bool>> predicate)
        {
            _logger.LogInformation("OrdersRepository {Method name}: Retrieving filtered orders", nameof(GetFilteredOrders));

            //Retrieve filtered orders based on the predicate, ordered by order date in descending order
            var filteredOrders = await _db.Orders.Where(predicate)
                .OrderByDescending(temp=> temp.OrderDate).ToListAsync();

            _logger.LogInformation($"Retrieved {filteredOrders.Count} filtered orders successfully");

            return filteredOrders;
        }

        ///<inheritdoc/>
        public async Task<Order?> GetOrderByOrderId(Guid orderId)
        {
            _logger.LogInformation("OrdersRepository {Method name}: Retrieving order with OrderID: {OrderID}", nameof(GetOrderByOrderId),orderId);

            //Find the order with specified order id
            var order = await _db.Orders.FindAsync(orderId);

            if (order == null)
            {
                _logger.LogWarning($"Order not found with the OrderId : {orderId}");
            }
            else
            {
                _logger.LogInformation($"Order found with the OrderId : {orderId}");
            }

            return order;
        }

        ///<inheritdoc/>
        public async Task<Order> UpdateOrder(Order order)
        {
            _logger.LogInformation("OrdersRepository {Method name}: Updating order with OrderID: {OrderID}", nameof(UpdateOrder), order.OrderId);

            //Find existing order in the database
            var existingOrder = await _db.Orders.FindAsync(order.OrderId);
            if(existingOrder == null)
            {
                _logger.LogWarning($"Order not found with the order id: {order.OrderId}");
                return order;
            }

            //Update the existing properties of the order with the new values
            existingOrder.OrderNumber = order.OrderNumber;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.TotalAmount = order.TotalAmount;

            return order;
        }
    }
}