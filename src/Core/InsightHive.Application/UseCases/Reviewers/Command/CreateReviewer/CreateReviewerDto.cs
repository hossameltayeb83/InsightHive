﻿namespace InsightHive.Application.UseCases.Reviewers.Command.CreateReviewer
{
    public class CreateReviewerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
