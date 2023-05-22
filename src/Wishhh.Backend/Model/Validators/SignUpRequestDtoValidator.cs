using System.Text.RegularExpressions;
using FluentValidation;
using Wishhh.Backend.Controllers;
using Wishhh.Backend.Repositories.Users;

namespace Wishhh.Backend.Model.Validators;

public partial class SignUpRequestDtoValidator : AbstractValidator<SignUpRequestDto>
{
    private readonly IUserRepository _users;

    public SignUpRequestDtoValidator(IUserRepository users)
    {
        _users = users;

        RuleFor(x => x.Username)
            .NotNull()
            .WithMessage("Поле \"Логин\" должно быть заполнено!")
            .Length(4, 48)
            .WithMessage("Логин должен быть от 4 до 48 символов!")
            .Must(MustContainOnlyLettersNumbersAndUnderscoresRegex().IsMatch)
            .WithMessage("В логине допустимо использовать только латиницу, числа и подчеркивания!")
            .MustAsync(UsernameIsNotTakenAsync)
            .WithMessage("Логин занят!");

        RuleFor(x => x.DisplayName)
            .NotNull()
            .WithMessage("Поле \"Имя\" должно быть заполнено!")
            .Length(1, 64)
            .WithMessage("Имя должно быть от 1 до 64 символов!");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("Поле \"Пароль\" должно быть заполнено!")
            .Length(8, 64)
            .WithMessage("Пароль должен быть от 8 до 64 символов!")
            .Must(MustContainAtLeastOneLetterOneNumberAndEightCharactersRegex().IsMatch)
            .WithMessage("В пароле должна быть как минимум 1 буква и 1 цифра");
    }

    private async Task<bool> UsernameIsNotTakenAsync(string username, CancellationToken _)
        => await _users.GetUserByUsernameAsync(username) is null;

    [GeneratedRegex("^[a-zA-Z0-9_]+$")]
    private static partial Regex MustContainOnlyLettersNumbersAndUnderscoresRegex();

    [GeneratedRegex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$")]
    private static partial Regex MustContainAtLeastOneLetterOneNumberAndEightCharactersRegex();
}