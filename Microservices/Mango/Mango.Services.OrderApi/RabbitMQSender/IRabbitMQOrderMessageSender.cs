namespace Mango.Services.OrderApi.RabbitMQSender
{
    public interface IRabbitMQOrderMessageSender
    {
        void SendMessage(object message, string exchangeName);
    }
}
