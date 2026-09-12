using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required.").MaximumLength(150);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.").MaximumLength(20);
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.").MaximumLength(200);
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is required.").MaximumLength(2000);
        }
    }

    public class UpdateContactStatusValidator : AbstractValidator<UpdateContactStatusDto>
    {
        public UpdateContactStatusValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid status.");
        }
    }
}