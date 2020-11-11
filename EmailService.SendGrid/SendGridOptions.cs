namespace EmailService.SendGrid
{
    public class SendGridOptions : ProviderOptions
    {
        public string ApiKey { get; set; } = "";
        public bool EnableClickTracking { get; set; } = false;
        public bool EnableClickTrackingText { get; set; } = false;
    }
}