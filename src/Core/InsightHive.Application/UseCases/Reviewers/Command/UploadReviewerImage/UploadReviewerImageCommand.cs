using InsightHive.Application.Responses;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Command.UploadReviewerImage
{
    public class UploadReviewerImageCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
    }
}
