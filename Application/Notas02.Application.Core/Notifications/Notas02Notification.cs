using System.Collections.Generic;

namespace Notas02.Application.Core.Notifications
{
    public class Notas02Notification
    {
        public bool Success { get; set; }
        public IDictionary<string, string> Results { get; set; }
    
        public Notas02Notification()
        {
            
        }
        public Notas02Notification(bool success)
        {
            Success = success;
        }
    }
}