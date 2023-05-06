using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus
{
  public class MessageBusService : IMessageBusService
  {
    private readonly ConnectionFactory _factory;
    public MessageBusService(IConfiguration configuration)
    {
      _factory = new ConnectionFactory
      {
        HostName = "localhost"
      };
    }
    public void Publish(string queue, byte[] message)
    {
      using (var connection = _factory.CreateConnection())
      {
        using (var channel = connection.CreateModel())
        {
          //grant queue creation
          channel.QueueDeclare(
              queue: queue,
              durable: false,
              exclusive: false,
              autoDelete: false,
              arguments: null
          );

          //publish message
          channel.BasicPublish(
            exchange: "",
            routingKey: queue,
            mandatory: false,
            basicProperties: null,
            body: message
          );
        }
      }
    }
  }
}