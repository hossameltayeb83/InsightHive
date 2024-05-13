using AutoMapper;
using FluentValidation;
using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Application.UseCases.Reviews.Command.CreateReview;
using InsightHive.Domain.Entities;
using MediatR;

namespace InsightHive.Application.UseCases.Reactions.Command.MakeReaction
{
    public class MakeReactionCommandHandler : IRequestHandler<MakeReactionCommand>
    {
        private readonly IRepository<Reaction> _reactionRepo;
        private readonly IRepository<ReviewReaction> _reviewReactionRepo;
        private readonly IValidator<MakeReactionCommand> _validator;

        public MakeReactionCommandHandler(IRepository<Reaction> reactionRepo,
                                          IRepository<ReviewReaction> reviewReactionRepo,
                                          IMapper mapper)
        {
            _reactionRepo = reactionRepo;
            _reviewReactionRepo = reviewReactionRepo;
            _validator = new MakeReactionCommandValidator();
        }
        public Task Handle(MakeReactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
