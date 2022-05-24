using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderService.Utilities.RabbitMq
{
    public static class StockScribe
    {
        private static readonly string _url = "amqps://fientxhx:GnS4aTKpa7dM-bGOhMhDn9v7qLZJ2tJZ@goose.rmq2.cloudamqp.com/fientxhx";

        public static void PublishStockNotification(DecrementRequest request)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(_url) };


            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            var queueName = "stockDecrementer";
            bool durable = true;
            bool exclusive = false;
            bool autoDelete = false;

            channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

            var json = JsonSerializer.Serialize(request);
            var data = Encoding.UTF8.GetBytes(json);
                // publish to the "default exchange", with the queue name as the routing key
            var exchangeName = "";
            var routingKey = queueName;
            channel.BasicPublish(exchangeName, routingKey, null, data);
        }
    }
}