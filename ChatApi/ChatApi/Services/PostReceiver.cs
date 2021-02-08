using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatApi.Hubs;
using ChatApi.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ChatApi.Services
{
    public class PostReceiver : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceProvider serviceProvider;

        public PostReceiver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "chatbot", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                //var updateCustomerFullNameModel = JsonConvert.DeserializeObject<string>(content); //en lugar de string, deeria haber una clase

                //HandleMessage(updateCustomerFullNameModel);
                var chatHub = (IHubContext<ChatHub>) serviceProvider.GetService(typeof(IHubContext<ChatHub>));
                //chatHub.Clients.All.SendAsync("MessageReceived", new MessageRequest { Message = content, User = new User { Username = "Chatbot" } });
                chatHub.Clients.All.SendAsync("MessageReceived", new PostRequest { Message = content, Username = "Chatbot", Timestamp = DateTime.Now });

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("chatbot", false, consumer);
            return Task.CompletedTask;
        }
    }
}
