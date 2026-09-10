using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateStatValidator : AbstractValidator<CreateStatDto>
    {
        public CreateStatValidator()
        {
            RuleFor(x => x.Label_En)
                .NotEmpty().WithMessage("Stat Label is required.")
                .MaximumLength(100).WithMessage("Stat Label must not exceed 100 characters.");

            RuleFor(x => x.Label_Ar)
                .NotEmpty().WithMessage("العنوان مطلوب")
                .MaximumLength(100).WithMessage("العنوان يجب ألا يتجاوز 100 حرفًا.");

            RuleFor(x => x.Value)
                .MaximumLength(100).WithMessage("Value must not exceed 100 characters.")
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThan(0).WithMessage("Display Order must be greater than 0.");
        }
    }

    public class UpdateStatValidator : AbstractValidator<UpdateStatDto>
    {
        public UpdateStatValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Stat Id must be greater than 0.");

            RuleFor(x => x.Label_En)
                .NotEmpty().WithMessage("Stat Label is required.")
                .MaximumLength(100).WithMessage("Stat Label must not exceed 100 characters.");

            RuleFor(x => x.Label_Ar)
                .NotEmpty().WithMessage("العنوان مطلوب")
                .MaximumLength(100).WithMessage("العنوان يجب ألا يتجاوز 100 حرفًا.");

            RuleFor(x => x.Value)
                .MaximumLength(100).WithMessage("Value must not exceed 100 characters.")
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThan(0).WithMessage("Display Order must be greater than 0.");
        }
    }

    public class DeleteStatValidator : AbstractValidator<int>
    {
        public DeleteStatValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Stat Id must be greater than 0.");
        }
    }
}
