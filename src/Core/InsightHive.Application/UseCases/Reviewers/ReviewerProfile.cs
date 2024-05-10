using AutoMapper;
using InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer;
using InsightHive.Application.UseCases.Reviewers.Command.UpdateReviewer;
using InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers;
using InsightHive.Application.UseCases.Reviewers.Query.GetReviewer;
using InsightHive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Reviewers
{
    public class ReviewerProfile : Profile
    {
        public ReviewerProfile()
        {
            //GetReviewer
            CreateMap<Badge, ReviewerBadgeDto>();

            CreateMap<Review, ReviewerReviewDto>()
                .ForMember(dest => dest.BusinessName, src => src.MapFrom(src => src.Business.Name));

            CreateMap<Reviewer, ReviewerDetailsDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.User.Email));

            //GetAllReviewers
            CreateMap<Reviewer, ReviewerListDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.User.Email));

            //createReviewer
            CreateMap<Reviewer, CreateReviewerDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.User.Email));

            CreateMap<CreateReviewerCommand, Reviewer>()
                .ForMember(dest => dest.User.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.User.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.User.Password, src => src.MapFrom(src => src.Password))
                .ForMember(dest => dest.User.RoleId, src => src.MapFrom(src => src.RoleId));

            //UpdateReviewer
            CreateMap<Reviewer, UpdateReviewerDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.User.Name));

            CreateMap<UpdateReviewerCommand, Reviewer>()
                .ForMember(dest => dest.User.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.User.Password, src => src.MapFrom(src => src.Password));




        }
    }
}
