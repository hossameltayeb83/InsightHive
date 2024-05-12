using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Application.UseCases.Reviewers.Command.UploadReviewerImage
{
    internal class UploadReviewerImageCommandValidator : AbstractValidator<UploadReviewerImageCommand>
    {
        public UploadReviewerImageCommandValidator()
        {
            RuleFor(e => e.Image)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} Max lenght is 50.");
        }
        
    }
}
