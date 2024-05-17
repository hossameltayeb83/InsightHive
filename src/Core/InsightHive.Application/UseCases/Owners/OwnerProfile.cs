using AutoMapper;
using InsightHive.Application.UseCases.Owners.command.CreateOwner;
using InsightHive.Application.UseCases.Owners.command.UpdateOwner;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Owners
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.BussnissName, opt => opt.MapFrom(src => src.Business.Name));

            CreateMap<OwnerDto, Owner>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    Name = src.Name,
                    Email = src.Email
                }))
                .ForMember(dest => dest.Business, opt => opt.MapFrom(src => new Business
                {
                    Name = src.BussnissName
                }));
            CreateMap<UpdateOwnerCommand, Owner>();

        }

    }
}