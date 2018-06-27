using System.Collections.Generic;

namespace Notas02.Application.Core.Notifications
{
    public class Notas02ErrorNotification : Notas02Notification
    {
        public bool Error { get; private set; }
        public IDictionary<string, string> Results { get; private set; }
        public Notas02ErrorNotification(IDictionary<string, string> results)
        {
            Error = true;
            Results = results;
        }
    }
}