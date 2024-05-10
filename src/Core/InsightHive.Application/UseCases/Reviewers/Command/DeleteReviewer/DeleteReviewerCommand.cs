using InsightHive.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Reviewers.Command.DeleteReviewer
{
    public class DeleteReviewerCommand : IRequest
    {
        public int Id { get; set; } 
        public int UserId { get; set; }

    }
}
