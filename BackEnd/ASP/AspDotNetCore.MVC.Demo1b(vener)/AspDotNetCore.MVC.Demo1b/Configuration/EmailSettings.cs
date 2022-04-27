namespace AspDotNetCore.MVC.Demo1b.Configuration
{
    public class EmailSettings
    {
        public string SMTPEmail { get; private set; }
        public string SMTPPassword { get; private set; }
        public string SMTPPort { get; private set; }
        public string SMTPHost { get; private set; }
    }
}
