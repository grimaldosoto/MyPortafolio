using Catalog.Application.Dtos.Technology.Request;
using FluentValidation;

namespace Catalog.Application.Validators.Technology
{
    public class TechnologyValidator : AbstractValidator<TechnologyRequestDto>
    {
        public TechnologyValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");
        }
    }
}
