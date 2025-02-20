namespace Mango.Services.ShoppingCartApi.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(object message, string queueName);
    }
}
