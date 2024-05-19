using AutoMapper;
using InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer;
using InsightHive.Application.UseCases.Reviewers.Command.UpdateReviewer;
using InsightHive.Application.UseCases.Reviewers.Query.GetAllReviewers;
using InsightHive.Application.UseCases.Reviewers.Query.GetReviewer;
using InsightHive.Domain.Entities;

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
                .ConstructUsing(src => new Reviewer
                {
                    User = new User
                    {
                        Name = src.Name,
                        Email = src.Email,
                        Password = src.Password,
                        RoleId = src.RoleId
                    }
                });

            //UpdateReviewer
            CreateMap<Reviewer, UpdateReviewerDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.User.Name));

            CreateMap<UpdateReviewerCommand, Reviewer>()
                       .ConstructUsing(src => new Reviewer
                       {
                           User = new User
                           {
                               Name = src.Name,
                               Password = src.Password  
                           }
                       });




        }
    }
}
