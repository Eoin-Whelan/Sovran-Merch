using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using OrderService.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Scribe
{
    /// <summary>
    /// Author:     Eoin Farrell
    /// Student No: C00164354
    /// 
    /// OrderScribe is a BackgroundService that listens for messages published to the
    /// orders RabbitMQ service. It then serializes, validates and posts the contents
    /// of the order passed via the queue and inserts it as a record on the orders SQL
    /// table.
    /// 
    /// 
    /// </summary>
    public class OrderScribe : BackgroundService
    {
        private readonly ILogger<OrderScribe> _logger;
        private ConnectionFactory _connectionFactory;
        private static IModel _channel;
        private IConnection _conn;
        private const string _queueName = "orders";

        bool durable = true;
        bool exclusive = false;
        bool autoDelete = false;

        private readonly string _url = "amqps://fientxhx:GnS4aTKpa7dM-bGOhMhDn9v7qLZJ2tJZ@goose.rmq2.cloudamqp.com/fientxhx";

        private ManualResetEvent _resetEvent = new ManualResetEvent(false);

        public OrderScribe(ILogger<OrderScribe> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(_url),
                DispatchConsumersAsync = true
            };

            _conn = _connectionFactory.CreateConnection();

            _channel = _conn.CreateModel();

            _channel.QueueDeclare(
                _queueName,
                durable,
                exclusive,
                autoDelete,
                null
            );

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += ConsumeMessage;
            Console.WriteLine("Task Complete!");
            _channel.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
        }

        private static async Task ConsumeMessage(object sender, BasicDeliverEventArgs @event)
        {

            var body = @event.Body.ToArray();
            // received message  
            var content = System.Text.Encoding.UTF8.GetString(body);
            Console.WriteLine("Here's the message");

            var newOrder = JsonSerializer.Deserialize<Order>(body);

            Console.WriteLine("And Here's the object!");

            var connectionString = @"Server=sovran-developer.cihpzkqwv66o.eu-west-1.rds.amazonaws.com;Database=sovran;User=scribe;Password=P3nc!lm3!n;";
            using (var conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("CREATE_NEW_ORDER", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                /*
                cmd.Parameters.Add(
                    new MySqlParameter("orderId", SqlDbType.Int));
                cmd.Parameters.Add(
                    new MySqlParameter("merchantId", SqlDbType.Int));
                cmd.Parameters.Add(
                   new MySqlParameter("itemId", SqlDbType.Int));
                cmd.Parameters.Add(
                    new MySqlParameter("itemDesc", SqlDbType.NVarChar));
                cmd.Parameters.Add(
                    new MySqlParameter("itemQty", SqlDbType.Int));

                cmd.Parameters["orderId"].Value = newOrder.OrderId;
                cmd.Parameters["merchantId"].Value = newOrder.MerchantId;
                cmd.Parameters["itemId"].Value = newOrder.ItemId;
                cmd.Parameters["itemDesc"].Value = newOrder.ItemDesc;
                cmd.Parameters["itemQty"].Value = newOrder.ItemQty;
                */
                cmd.Parameters.AddWithValue("orderId", newOrder.OrderId);
                //cmd.Parameters.AddWithValue("merchantId", newOrder.MerchantId);
                cmd.Parameters.AddWithValue("itemId", newOrder.ItemId);
                //cmd.Parameters.AddWithValue("itemDesc", newOrder.ItemDesc);
                cmd.Parameters.AddWithValue("itemQty", newOrder.ItemQty);

                try
                {
                    conn.Open();
                    await cmd.ExecuteNonQueryAsync();
                    _channel.BasicAck(@event.DeliveryTag, false);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    _channel.BasicNack(@event.DeliveryTag, false, true);

                }
                conn.Close();
            };


        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
            _conn.Close();
            _logger.LogInformation("We're quitting out");
        }
    }
}
