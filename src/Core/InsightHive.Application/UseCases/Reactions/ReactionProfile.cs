using AutoMapper;
using InsightHive.Application.UseCases.Reactions.Command;
using InsightHive.Domain.Entities;

namespace InsightHive.Application.UseCases.Reactions
{
    public class ReactionProfile : Profile
    {
        public ReactionProfile()
        {
            CreateMap<ReviewReaction, ReviewReactionDto>();
        }
    }
}
