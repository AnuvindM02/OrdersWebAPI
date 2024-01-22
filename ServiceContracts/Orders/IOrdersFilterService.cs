using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Orders
{
    /// <summary>
    /// Service for retrieving filtered orders
    /// </summary>
    public interface IOrdersFilterService
    {
        /// <summary>
        /// Retrieves filtered orders based on search criteria.
        /// </summary>
        /// <param name="searchBy">The field to search by.</param>
        /// <param name="searchString">The search string.</param>
        /// <returns>A list of filtered orders.</returns>
        Task<List<OrderResponse>> GetFilteredOrders(string searchBy, string? searchString);
    }
}
