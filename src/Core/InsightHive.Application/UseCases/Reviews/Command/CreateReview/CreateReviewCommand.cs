using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.CreateReview
{
    public class CreateReviewCommand : IRequest<BaseResponse<CreateReviewDto>>
    {
        public int ReviewerId { get; set; }
        public int BusinessId { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; }
        public string? Image { get; set; }
    }
}
