using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets unique identifieer of the order
        /// </summary>
        [Key]
        public Guid OrderId { get; set; }


        /// <summary>
        /// Gets or sets name of the customer associated with the order
        /// </summary>
        [Required(ErrorMessage ="The CustomerName field is required.")]
        [StringLength(50,ErrorMessage ="CustomerName field must not exceed 50 characters.")]
        public string? CustomerName {  get; set; }


        /// <summary>
        /// Gets or sets order number
        /// </summary>
        [RegularExpression(@"^(?i)ORD_\d{4}_\d+$\r\n",ErrorMessage ="The order number should begin with 'ORD' followed by an underscore (_) and a sequential number.")]
        public string? OrderNumber {  get; set; }


        /// <summary>
        /// Gets or sets the date of the order
        /// </summary>
        [Required(ErrorMessage ="The OrderDate Field is required.")]
        public DateTime OrderDate { get; set; }


        /// <summary>
        /// Gets or sets total amount of the order
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage ="Total amount field must be a positive number.")]
        [Column(TypeName ="decimal")]
        public decimal TotalAmount {  get; set; }
    }
}
