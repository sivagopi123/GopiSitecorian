using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        //POST 
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _context.Attendances
                            .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (attendance != null)
            {
                if (attendance.IsActive)
                    return BadRequest("Attendance already recorded!");
                else
                {
                    attendance.EnableAttendance();
                    _context.SaveChanges();
                    return Ok();
                }
            }
            attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnAttend(int Id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _context.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == Id);
            if (attendance != null)
            {
                if (attendance.IsActive)
                {
                    attendance.DisableAttendance();
                    _context.SaveChanges();
                    return Ok(Id);
                }
                
            }
            return BadRequest("You are not attending the Gig already");
        }
    }
}
