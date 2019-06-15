using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace OwinKatanaProject.Models
{
    public class LoginModel
    {
        public List<AuthenticationDescription> LoginProviders;

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}