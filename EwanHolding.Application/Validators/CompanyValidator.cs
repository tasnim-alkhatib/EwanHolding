using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name_En)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.");

            RuleFor(x => x.Name_Ar)
                .NotEmpty().WithMessage("اسم الشركة مطلوب.")
                .MaximumLength(200).WithMessage("اسم الشركة يجب ألا يتجاوز 200 حرف.");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("Company description is required.")
                .MaximumLength(2000).WithMessage("Company description must not exceed 2000 characters.");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("وصف الشركة مطلوب.")
                .MaximumLength(2000).WithMessage("وصف الشركة يجب ألا يتجاوز 2000 حرف.");

            RuleFor(x => x.WebsiteUrl)
                //.NotEmpty().WithMessage("Website URL is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid website URL format.");

            RuleFor(x => x.LogoUrl)
                //.NotEmpty().WithMessage("Logo URL is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid logo URL format.");
        }
    }

    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyDto>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Name_En)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.");

            RuleFor(x => x.Name_Ar)
                .NotEmpty().WithMessage("اسم الشركة مطلوب.")
                .MaximumLength(200).WithMessage("اسم الشركة يجب ألا يتجاوز 200 حرف.");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("Company description is required.")
                .MaximumLength(2000).WithMessage("Company description must not exceed 2000 characters.");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("وصف الشركة مطلوب.")
                .MaximumLength(2000).WithMessage("وصف الشركة يجب ألا يتجاوز 2000 حرف.");

            RuleFor(x => x.WebsiteUrl)
                //.NotEmpty().WithMessage("Website URL is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid website URL format.");

            RuleFor(x => x.LogoUrl)
                //.NotEmpty().WithMessage("Logo URL is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid logo URL format.");
        }
    }
}
