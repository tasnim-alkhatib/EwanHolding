using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateTermsAndConditionsValidator : AbstractValidator<CreateTermsAndConditionsDto>
    {
        public CreateTermsAndConditionsValidator()
        {
            RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Title is required.").MaximumLength(200);
            RuleFor(x => x.TitleAr).NotEmpty().WithMessage("العنوان مطلوب.").MaximumLength(200);
            RuleFor(x => x.Description_En).NotEmpty().WithMessage("Description is required.").MaximumLength(5000);
            RuleFor(x => x.Description_Ar).NotEmpty().WithMessage("الوصف مطلوب.").MaximumLength(5000);
        }
    }

    public class UpdateTermsAndConditionsValidator : AbstractValidator<UpdateTermsAndConditionsDto>
    {
        public UpdateTermsAndConditionsValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Title is required.").MaximumLength(200);
            RuleFor(x => x.TitleAr).NotEmpty().WithMessage("العنوان مطلوب.").MaximumLength(200);
            RuleFor(x => x.Description_En).NotEmpty().WithMessage("Description is required.").MaximumLength(5000);
            RuleFor(x => x.Description_Ar).NotEmpty().WithMessage("الوصف مطلوب.").MaximumLength(5000);
        }
    }
}