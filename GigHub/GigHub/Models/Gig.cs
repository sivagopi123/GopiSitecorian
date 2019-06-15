using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

        public bool IsCancelled { get; private set; }

        public ICollection<Attendance> Attendances { get; private set; }
        public Gig()
        {
            Attendances = new Collection<Attendance>();
            Notification.gigCreated(this);
        }

        public void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.gigCancelled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Update(DateTime gigDateTime, string gigVenue, byte gigGenre)
        {

            var notification = Notification.gigUpdated(this, this.DateTime, this.Venue);

            this.DateTime = gigDateTime;
            this.Venue = gigVenue;
            this.GenreId = gigGenre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public bool IsUserAttending(string userId)
        {
            return Attendances.Where(a => a.AttendeeId == userId).Count() > 0 ? true : false;
        }

        public bool IsUserFollowing(string userId)
        {
            return Artist.Followees.Where(f => f.FolloweeId == userId).Count() > 0 ? true : false;
        }

    }
}