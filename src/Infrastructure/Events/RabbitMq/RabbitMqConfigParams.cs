namespace SharedKernel.Infrastructure.Events.RabbitMq
{
    public class RabbitMqConfigParams
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string HostName { get; set; }

        public string ExchangeName { get; set; }

        public int Port { get; set; }
    }
}