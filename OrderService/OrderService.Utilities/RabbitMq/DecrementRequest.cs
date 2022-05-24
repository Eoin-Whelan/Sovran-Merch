using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Utilities.RabbitMq
{
    /// <summary>
    /// Main container class for stock decrement details.
    /// </summary>
    public class DecrementRequest
    {
        /// <summary>
        /// Username of merchant whom's stock is being accessed.
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// Id of their respective stock item.
        /// </summary>
        public string itemId { get; set; }
        /// <summary>
        /// Detail is for the respective stock item's measurements, size, etc.
        /// </summary>
        public string detail { get; set; }
        /// <summary>
        /// The number of this item to decrement. Given current progress, this will be limited to one item.
        /// </summary>
        public int quantity { get; set; }
    }
}
