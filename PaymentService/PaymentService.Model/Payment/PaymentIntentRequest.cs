using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model.Payment
{
    /// <summary>
    /// Unused implementation for Stripe Connect's inventory API. 
    /// </summary>
    public class Item

    {

        [JsonProperty("id")]
        public string Id { get; set; }

    }

    /// <summary>
    /// Request object used in generating a Stripe Payment Intent. Intents are
    ///  used in generating clientside secrets to pass separately to Stripe in
    ///   order to process a payment.
    /// </summary>
    public class PaymentIntentCreateRequest

    {

        [JsonProperty("accId")]
        public string accId { get; set; } 
        [JsonProperty("amount")]
        public long amount { get; set; }


        [JsonProperty("items")]
        public Item[] Items { get; set; }

    }
}
