using AutoMapper;
using InsightHive.Application.Responses;
using InsightHive.Domain.Entities;
using InsightHive.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace InsightHive.Identity
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<User, AppUser>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                    .ReverseMap();

            CreateMap<IdentityResult, AuthenticationResponse>()
                        .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors.Select(e => e.Description).ToArray()));
        }
    }
}
