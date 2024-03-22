namespace Application.Models.Email
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            FromAddress = string.Empty;
            FromName = string.Empty;
        }

        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
