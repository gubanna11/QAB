using FluentValidation;
using QAB.Services.Models.Dtos.Case;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Services.Validators
{
    public class CaseRequestDtoValidator : AbstractValidator<CaseRequestDto>
    {
        public CaseRequestDtoValidator()
        {
            RuleFor(c => c.AuthorId)
                .NotEmpty();

            RuleFor(c => c.Title)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(c => c.Description)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(c => c.Content)
                .NotEmpty()
                .MinimumLength(50)
                .MaximumLength(120000);
        }
    }
}
