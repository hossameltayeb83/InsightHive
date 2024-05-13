using AutoMapper;
using InsightHive.Application.Models.Review;
using InsightHive.Application.UseCases.Reviews.Command.CreateComment;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Application.UseCases.Reviews.Command.UpdateReview;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Reviews
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            // create
            CreateMap<CommentDto, Comment>();
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<CreateCommentCommand, ReviewComment>()
                        .ForMember(dest => dest.ReviewerId, opt => opt.MapFrom(src => src.CommenterId));
            CreateMap<CreateCommentCommand, CommentDto>();
        }
    }
}
