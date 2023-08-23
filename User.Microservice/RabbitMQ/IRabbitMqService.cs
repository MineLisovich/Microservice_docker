namespace User.Microservice.RabbitMQ
{
    public interface IRabbitMqService
    {
        public void SendProductMessage<T>(T message);
    }
}
