namespace EmailService.SendGrid
{
    public class SendGridSettings : ProviderSettings
    {
        public string ApiKey { get; set; } = "";
        public bool EnableClickTracking { get; set; } = false;
        public bool EnableClickTrackingText { get; set; } = false;
    }
}