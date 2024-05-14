using InsightHive.Application.Responses;
using InsightHive.Domain.Enums;
using MediatR;

namespace InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer
{
    public class CreateReviewerCommand : IRequest<BaseResponse<CreateReviewerDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int RoleId { get; set; }
    }
}
