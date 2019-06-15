using System;

namespace MvcIoc.Models
{
    public class DebugMessageService : IDebugMessageService
    {
        public string Message { get { return DateTime.Now.ToString(); } }
    }
}