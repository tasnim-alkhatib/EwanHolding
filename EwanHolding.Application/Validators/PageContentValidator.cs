using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreatePageContentValidator : AbstractValidator<CreatePageContentDto>
    {
        public CreatePageContentValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required.").MaximumLength(100);
            RuleFor(x => x.Value_Ar).NotEmpty().WithMessage("Value (Ar) is required.").MaximumLength(4000);
            RuleFor(x => x.Value_En).NotEmpty().WithMessage("Value (En) is required.").MaximumLength(4000);
            RuleFor(x => x.PageName).NotEmpty().WithMessage("Page name is required.").MaximumLength(100);
        }
    }

    public class UpdatePageContentValidator : AbstractValidator<UpdatePageContentDto>
    {
        public UpdatePageContentValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Value_Ar).NotEmpty().WithMessage("Value (Ar) is required.").MaximumLength(4000);
            RuleFor(x => x.Value_En).NotEmpty().WithMessage("Value (En) is required.").MaximumLength(4000);
        }
    }
}