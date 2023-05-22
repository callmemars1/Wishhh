using FluentValidation;
using Wishhh.Backend.Controllers;

namespace Wishhh.Backend.Model.Validators;

public class SetNameRequestValidator : AbstractValidator<SetNameRequestDto>
{
    public SetNameRequestValidator()
    {
        RuleFor(x => x.DisplayName)
            .NotNull()
            .WithMessage("Поле \"Имя\" должно быть заполнено!")
            .Length(1, 64)
            .WithMessage("Имя должно быть от 1 до 64 символов!");
    }
}