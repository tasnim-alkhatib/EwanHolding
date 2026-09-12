using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateNewsValidator : AbstractValidator<CreateNewsDto>
    {
        public CreateNewsValidator()
        {
            RuleFor(x => x.Title_En).NotEmpty().WithMessage("Title is required.").MaximumLength(200);
            RuleFor(x => x.Title_Ar).NotEmpty().WithMessage("العنوان مطلوب.").MaximumLength(200);
            RuleFor(x => x.Description_En).NotEmpty().WithMessage("Description is required.").MaximumLength(2000);
            RuleFor(x => x.Description_Ar).NotEmpty().WithMessage("الوصف مطلوب.").MaximumLength(2000);
            RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid status.");
        }
    }

    public class UpdateNewsValidator : AbstractValidator<UpdateNewsDto>
    {
        public UpdateNewsValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Title_En).NotEmpty().WithMessage("Title is required.").MaximumLength(200);
            RuleFor(x => x.Title_Ar).NotEmpty().WithMessage("العنوان مطلوب.").MaximumLength(200);
            RuleFor(x => x.Description_En).NotEmpty().WithMessage("Description is required.").MaximumLength(2000);
            RuleFor(x => x.Description_Ar).NotEmpty().WithMessage("الوصف مطلوب.").MaximumLength(2000);
            RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid status.");
        }
    }
}