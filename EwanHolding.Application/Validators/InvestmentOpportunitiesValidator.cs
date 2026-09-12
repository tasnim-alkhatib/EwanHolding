using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateInvestmentOpportunitiesValidator : AbstractValidator<CreateInvestmentOpportunitiesDto>
    {
        public CreateInvestmentOpportunitiesValidator()
        {
            RuleFor(x => x.Title_En)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Title_Ar)
                .NotEmpty().WithMessage("العنوان مطلوب.")
                .MaximumLength(200).WithMessage("العنوان يجب ألا يتجاوز 200 حرف.");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("الوصف مطلوب.")
                .MaximumLength(2000).WithMessage("الوصف يجب ألا يتجاوز 2000 حرف.");

            RuleFor(x => x.CompanyId)
                .GreaterThan(0).WithMessage("Company ID must be greater than 0.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid investment status.");
        }
    }

    public class UpdateInvestmentOpportunitiesValidator : AbstractValidator<UpdateInvestmentOpportunitiesDto>
    {
        public UpdateInvestmentOpportunitiesValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Title_En)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Title_Ar)
                .NotEmpty().WithMessage("العنوان مطلوب.")
                .MaximumLength(200).WithMessage("العنوان يجب ألا يتجاوز 200 حرف.");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("الوصف مطلوب.")
                .MaximumLength(2000).WithMessage("الوصف يجب ألا يتجاوز 2000 حرف.");

            RuleFor(x => x.CompanyId)
                .GreaterThan(0).WithMessage("Company ID must be greater than 0.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid investment status.");
        }
    }
}