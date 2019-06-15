using System.Diagnostics;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        //private string _mailTo = Startup._configuration["mailSettings:mailToAddress"];
        //private string _mailFrom = Startup._configuration["mailSettings:mailFromAddress"];

        private string _mailTo = "test";
        private string _mailFrom = "test";
        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail form {_mailFrom} is sent to {_mailTo}");
            Debug.WriteLine($"{subject}");
            Debug.WriteLine($"{message}");
        }
    }
}
