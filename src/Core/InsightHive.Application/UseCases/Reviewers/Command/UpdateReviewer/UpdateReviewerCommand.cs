using InsightHive.Application.Responses;
using InsightHive.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Reviewers.Command.UpdateReviewer
{
    public class UpdateReviewerCommand : IRequest<BaseResponse<UpdateReviewerDto>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
