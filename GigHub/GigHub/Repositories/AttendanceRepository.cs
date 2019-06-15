using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public ApplicationDbContext _context { get; set; }

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetFutureAttendances(string currentUserId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == currentUserId)
                .ToList();
        }
    }
}