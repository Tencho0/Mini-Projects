namespace Mango.Services.EmailApi.Messaging
{
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Mango.Services.EmailApi.Message;
    using Mango.Services.EmailApi.Services;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class RabbitMQOrderConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQOrderConsumer(IConfiguration configuration, EmailService emailService)
        {
            _configuration = configuration;
            _emailService = emailService;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic"), false, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var email = JsonConvert.DeserializeObject<RewardsMessage>(content);
                HandleMessage(email).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic"), false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(RewardsMessage email)
        {
            _emailService.LogOrderPlaced(email).GetAwaiter().GetResult();
        }
    }
}
