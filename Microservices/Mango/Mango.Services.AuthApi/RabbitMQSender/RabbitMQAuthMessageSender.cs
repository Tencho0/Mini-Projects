﻿namespace Mango.Services.AuthApi.RabbitMQSender
{
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client;

    public class RabbitMQAuthMessageSender : IRabbitMQAuthMessageSender
    {
        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQAuthMessageSender()
        {
            _hostName = "localhost";
            _username = "guest";
            _password = "guest";
        }

        public void SendMessage(object message, string queueName)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queueName, false, false, false, null);
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: queueName, null, body: body);
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    Password = _password,
                    UserName = _username
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {

            }
        }

        private bool ConnectionExists()
        {
            if (_connection == null)
            {
                return true;
            }

            CreateConnection();
            return true;
        }
    }
}
