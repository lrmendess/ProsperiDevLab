namespace ProsperiDevLab.Services.Notificator
{
    public class Notification
    {
        public NotificationType Type { get; }
        public string Property { get; set; }
        public string Message { get; }

        public Notification(NotificationType type, string property = "", string message = "")
        {
            Type = type;
            Property = property;
            Message = message;
        }
    }
}
