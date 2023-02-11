using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServiceBasedRabbit.Core.Interfaces.MessageBroker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WorkerServiceBasedRabbitMQ.Core.Interfaces;
using WorkerServiceBasedRabbitMQ.Core.Models;
using WorkerServiceBasedRabbitMQ.Infrastructure.Repositories;

namespace ServiceBasedRabbit.Infrastructure.MessageBroker
{



    public class RabbitMQSubscriber : IRabbitMQSubscriber
    {

        public RabbitMQSubscriber()
        {

        }



        public IEnumerable<User> Subscribe()
        {
            List<User> list = new List<User>();
            // List<T> list = new List<T>();

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();


            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "UserItemQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            // Waiting for messages...
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var user = JsonSerializer.Deserialize<User>(message);

                    Console.WriteLine($" [x] Received {message}");

                    channel.BasicAck(ea.DeliveryTag, false);
                    Console.WriteLine($" [x] ea.DeliveryTag {ea.DeliveryTag}");

                    // Create List of..
                    list.Add(user);
                }
                catch (Exception ex)
                {
                    //throw;
                    channel.BasicNack(ea.DeliveryTag, false, true);

                }
            };
            channel.BasicConsume(queue: "UserItemQueue",
                                 autoAck: false,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            return list;


        }



    }
}
