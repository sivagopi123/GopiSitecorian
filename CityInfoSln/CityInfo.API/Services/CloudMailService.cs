using System;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        //private string _mailTo = Startup._configuration["mailSettings:mailToAddress"];
        //private string _mailFrom = Startup._configuration["mailSettings:mailFromAddress"];

        private string _mailTo = "test";
        private string _mailFrom = "test";
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail form {_mailFrom} is sent to {_mailTo}");
            Console.WriteLine($"{subject}");
            Console.WriteLine($"{message}");
        }
    }
}
