using AutoMapper;
using InsightHive.Application.UseCases.Users.Command.Register;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterCommand, User>();
        }
    }
}
