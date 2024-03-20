namespace Domain.Configuration
{
    public class Secrets
    {
        public Secrets()
        {

            Rabbit_Hostname = string.Empty;
            Rabbit_Port = "5672";
            Rabbit_Username = string.Empty;
            Rabbit_Password = string.Empty;
            ExchangeEspelhoPonto = string.Empty;
            Rabbit_VirtualHost = string.Empty;
            QueueEspelhoPonto = string.Empty;
        }

        public string Rabbit_Hostname { get; set; }
        public string Rabbit_Port { get; set; }
        public string Rabbit_Username { get; set; }
        public string Rabbit_Password { get; set; }
        public string ExchangeEspelhoPonto { get; set; }
        public string QueueEspelhoPonto { get; set; }
        public string Rabbit_VirtualHost { get; set; }
    }
}