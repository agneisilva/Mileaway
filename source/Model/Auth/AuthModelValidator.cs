using FluentValidation;

namespace Architecture.Model
{
    public sealed class AuthModelValidator : AbstractValidator<AuthModel>
    {
        public AuthModelValidator()
        {
            RuleFor(auth => auth.Login).NotEmpty();
            RuleFor(auth => auth.Senha).NotEmpty();
            RuleFor(auth => auth.Roles).NotEmpty();
        }
    }
}
