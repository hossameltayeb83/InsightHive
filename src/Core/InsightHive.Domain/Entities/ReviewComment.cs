﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class ReviewComment
    {
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}