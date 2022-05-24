using System;

namespace OrderService.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string MerchantUsername { get; set; }
        public string ItemId { get; set; }
        public string Measurement { get; set; }
        public int ItemQty { get; set; }
    }
}