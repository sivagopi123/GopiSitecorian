namespace GigHub.Dtos
{
    public class UserNotificationDto
    {
        public string UserId { get; set; }
        public int NotificationId { get; set; }

        public ApplicationUserDto User { get; private set; }

        public NotificationDto Notification { get; private set; }

        public bool IsRead { get; set; }
    }
}