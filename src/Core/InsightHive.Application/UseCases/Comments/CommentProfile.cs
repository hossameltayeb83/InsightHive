using AutoMapper;
using InsightHive.Application.Models.Review;
using InsightHive.Application.UseCases.Reviews.Command.CreateComment;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Comments
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentCommand, Comment>()
                        .ForMember(dest => dest.ReviewerId, opt => opt.MapFrom(src => src.CommenterId));

            CreateMap<Comment, CommentDto>()
                 .ForMember(dest => dest.CommenterId, opt => opt.MapFrom(src => src.ReviewerId));
        }
    }
}
