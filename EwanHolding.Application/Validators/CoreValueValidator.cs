using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateCoreValueValidator: AbstractValidator<CreateCoreValueDto>
    {
        public CreateCoreValueValidator()
        {
            RuleFor(x => x.Title_En)
                .NotEmpty().WithMessage("The title is required")
                .MaximumLength(200).WithMessage("The title cannot exceed 200 characters");

            RuleFor(x => x.Title_Ar)
                .NotEmpty().WithMessage("العنوان مطلوب")
                .MaximumLength(200).WithMessage("لا يمكن أن يتجاوز عنوان 200 حرف");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("The description is required")
                .MaximumLength(2000).WithMessage("The description cannot exceed 2000 characters");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("الوصف مطلوب")
                .MaximumLength(2000).WithMessage("لا يمكن أن يتجاوز وصف 2000 حرف");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Display order must be greater than or equal to 0");

            RuleFor(x => x.IconUrl)
                .NotEmpty().WithMessage("The icon URL is required")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid website URL format.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Display order must be greater than or equal to 0");
        }
    }

    public class UpdateCoreValueValidator: AbstractValidator<UpdateCoreValueDto>
    {
        public UpdateCoreValueValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Title_En)
                .NotEmpty().WithMessage("The title is required")
                .MaximumLength(200).WithMessage("The title cannot exceed 200 characters");

            RuleFor(x => x.Title_Ar)
                .NotEmpty().WithMessage("العنوان مطلوب")
                .MaximumLength(200).WithMessage("لا يمكن أن يتجاوز عنوان 200 حرف");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("The description is required")
                .MaximumLength(2000).WithMessage("The description cannot exceed 2000 characters");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("الوصف مطلوب")
                .MaximumLength(2000).WithMessage("لا يمكن أن يتجاوز وصف 2000 حرف");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Display order must be greater than or equal to 0");

            RuleFor(x => x.IconUrl)
                .NotEmpty().WithMessage("The icon URL is required")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid website URL format.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Display order must be greater than or equal to 0");
        }
    }
}
