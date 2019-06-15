

using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notification, NotificationDto>();
                cfg.CreateMap<Gig, GigDto>();
                cfg.CreateMap<ApplicationUser, ApplicationUserDto>();
            });
            config.CreateMapper();
        }
    }
}