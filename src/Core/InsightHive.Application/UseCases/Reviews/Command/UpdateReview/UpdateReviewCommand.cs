using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviews.Command.UpdateReview
{
    public class UpdateReviewCommand : IRequest<BaseResponse<UpdateReviewDto>>
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; }
        public string? Image { get; set; }
    }
}
