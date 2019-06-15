using GigHub.Repositories;

namespace GigHub.Persistence
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; }
        IFollowerRepository Followers { get; }
        IGenreRepository Genres { get; }
        IGigsRepository Gigs { get; }

        void Complete();
    }
}