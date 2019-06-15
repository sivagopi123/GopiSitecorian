using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }
        protected Notification()
        {

        }
        private Notification(Gig gig, NotificationType type)
        {
            this.DateTime = DateTime.Now;
            this.Gig = gig ?? throw new ArgumentNullException("gig");
            this.Type = type;
        }

        public static Notification gigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }
        public static Notification gigUpdated(Gig gig, DateTime OldDateTime, string OldVenue)
        {
            return new Notification(gig, NotificationType.GigUpdated)
            {
                OriginalDateTime = OldDateTime,
                OriginalVenue = OldVenue
            };
        }

        public static Notification gigCancelled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCancelled);
        }
    }
}
