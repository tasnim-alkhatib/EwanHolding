using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceDto>   
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.Name_En)
                .NotEmpty().WithMessage("Service name is required.")
                .MaximumLength(200).WithMessage("Service name must not exceed 200 characters.");

            RuleFor(x => x.Name_Ar)
                .NotEmpty().WithMessage("اسم الخدمة مطلوب.")
                .MaximumLength(200).WithMessage("اسم الخدمة يجب ألا يتجاوز 200 حرف.");

            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("Service description is required.")
                .MaximumLength(2000).WithMessage("Service description must not exceed 2000 characters.");

            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("وصف الخدمة مطلوب.")
                .MaximumLength(2000).WithMessage("وصف الخدمة يجب ألا يتجاوز 2000 حرف.");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.")
                .GreaterThan(0).WithMessage("Company ID must be greater than 0.");
        }
    }

    public class UpdateServiceValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Service ID is required.")
                .GreaterThan(0).WithMessage("Service ID must be greater than 0.");
           
            RuleFor(x => x.Name_En)
                .NotEmpty().WithMessage("Service name is required.")
                .MaximumLength(200).WithMessage("Service name must not exceed 200 characters.");
            
            RuleFor(x => x.Name_Ar)
                .NotEmpty().WithMessage("اسم الخدمة مطلوب.")
                .MaximumLength(200).WithMessage("اسم الخدمة يجب ألا يتجاوز 200 حرف.");
            
            RuleFor(x => x.Description_En)
                .NotEmpty().WithMessage("Service description is required.")
                .MaximumLength(2000).WithMessage("Service description must not exceed 2000 characters.");
            
            RuleFor(x => x.Description_Ar)
                .NotEmpty().WithMessage("وصف الخدمة مطلوب.")
                .MaximumLength(2000).WithMessage("وصف الخدمة يجب ألا يتجاوز 2000 حرف.");
            
            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.")
                .GreaterThan(0).WithMessage("Company ID must be greater than 0.");
        }
    }

    public class DeleteServiceValidator : AbstractValidator<int>
    {
        public DeleteServiceValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Service Id must be greater than 0.");
        }
    }
}
