using Microsoft.AspNetCore.Mvc;
using OrderService.Model;
using OrderService.Utilities.RabbitMq;
using Sovran.Logger;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {

        }

        [Route("/Orders/CreateOrder")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order newOrder)
        {
            try
            {
                StockScribe.PublishStockNotification(new DecrementRequest
                {
                    userName = newOrder.MerchantUsername,
                    detail = newOrder.Measurement,
                    itemId = newOrder.ItemId,
                    quantity = newOrder.ItemQty
                });
                
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}