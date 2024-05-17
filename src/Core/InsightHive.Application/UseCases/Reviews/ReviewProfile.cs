using AutoMapper;
using InsightHive.Application.Models.Review;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Application.UseCases.Reviews.Command.UpdateReview;
using InsightHive.Domain.Entities;
using InsightHive.Domain.Enums;

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
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Image, opt => opt.NullSubstitute("n/a"));

            CreateMap<ICollection<ReviewReaction>, Dictionary<ReactionValue, int>>()
                .ConstructUsing(e => new Dictionary<ReactionValue, int>
                {
                    { ReactionValue.Like, e.Count(e => e.Reaction.Name == ReactionValue.Like) },
                    { ReactionValue.Dislike, e.Count(e => e.Reaction.Name == ReactionValue.Dislike) },
                    { ReactionValue.Helpful, e.Count(e => e.Reaction.Name == ReactionValue.Helpful) },
                    { ReactionValue.Exciting, e.Count(e => e.Reaction.Name == ReactionValue.Exciting) }
                });
        }
    }
}
