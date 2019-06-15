using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> getNotificationList()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                                    .Where(un => un.UserId == userId && !un.IsRead)
                                    .Select(un => un.Notification)
                                    .Include(n => n.Gig.Artist)
                                    .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
            /**Mannual Mapping of DTO objects*/
            //return notifications.Select(n => new NotificationDto() {
            //    DateTime = n.DateTime,
            //    Gig = new GigDto
            //    {
            //        Artist = new ApplicationUserDto
            //        {
            //            Id = n.Gig.Artist.Id,
            //            Name = n.Gig.Artist.Name
            //        },
            //        DateTime = n.Gig.DateTime,
            //        Id = n.Gig.Id,
            //        IsCancelled = n.Gig.IsCancelled,
            //        Venue = n.Gig.Venue
            //    },
            //    OriginalVenue = n.OriginalVenue,
            //    OriginalDateTime = n.OriginalDateTime,
            //    Type =n.Type
            //});

        }
        [HttpPost]
        public IHttpActionResult MarkAllAsRead()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = _context.UserNotifications.Where(un => un.UserId == userId && !un.IsRead).ToList();

            userNotifications.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok(userNotifications);
        }

        [HttpPost]
        public IHttpActionResult MarkOneAsRead(int Id)
        {
            var userId = User.Identity.GetUserId();
            var result = _context.UserNotifications.Where(un => un.NotificationId == Id).ToList();

            result.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok(result);
        }
    }
}
