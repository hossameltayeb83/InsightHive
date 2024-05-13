using AutoMapper;
using InsightHive.Application.Models.Review;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Application.UseCases.Reviews.Command.UpdateReview;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Reviews
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            // create
            CreateMap<CreateReviewCommand, Review>();
            CreateMap<Review, CreateReviewDto>();
            // update
            CreateMap<UpdateReviewCommand, Review>();
            CreateMap<Review, UpdateReviewDto>();
            // query review dto
            CreateMap<ReviewComment, CommentDto>()
                        .ForMember(dest => dest.CommenterId, opt => opt.MapFrom(src => src.ReviewerId))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CommentId))
                        .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Comment.Content))
                        .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Comment.CreatedDate))
                        .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => src.Comment.LastModifiedDate));

            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Image, opt => opt.NullSubstitute("n/a"));
        }
    }
}
