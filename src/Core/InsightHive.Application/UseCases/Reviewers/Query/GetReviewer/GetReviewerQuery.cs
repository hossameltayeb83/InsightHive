﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Reviewers.Query.GetReviewer
{
    public class GetReviewerQuery : IRequest<ReviewerDetailsDto>
    {
        public int Id { get; set; }
    }
}
