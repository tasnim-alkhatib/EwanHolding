using EwanHolding.Application.DTOs;
using FluentValidation;

namespace EwanHolding.Application.Validators
{
    public class CreateMediaValidator : AbstractValidator<CreateMediaDto>
    {
        public CreateMediaValidator()
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url is required.").MaximumLength(500);
            RuleFor(x => x.EntityId).GreaterThan(0).WithMessage("EntityId must be greater than 0.");
            RuleFor(x => x.EntityType).IsInEnum().WithMessage("Invalid entity type.");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Invalid media type.");
            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0).WithMessage("Display order must be >= 0.");
        }
    }
}