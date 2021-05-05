using FluentValidation;

namespace Architecture.Model.Auth
{
    public sealed class EsqueceuSenhaModelValidator : AbstractValidator<EsqueceuSenhaModel>
    {
        public EsqueceuSenhaModelValidator()
        {
            RuleFor(esqueceuSenha => esqueceuSenha.Email).NotEmpty();
            RuleFor(esqueceuSenha => esqueceuSenha.RedirectRoute).NotEmpty();
        }
    }
}
