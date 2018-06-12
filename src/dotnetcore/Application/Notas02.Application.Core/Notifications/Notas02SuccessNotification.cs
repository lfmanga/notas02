namespace Notas02.Application.Core.Notifications
{
    public class Notas02SuccessNotification : Notas02Notification
    {
        public bool Success { get; private set; }
        public Notas02SuccessNotification ()
        {
            Success = true;
        }
    }
}