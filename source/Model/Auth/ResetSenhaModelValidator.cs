using FluentValidation;

namespace Architecture.Model.Auth
{
    public sealed class ResetSenhaModelValidator : AbstractValidator<ResetarSenhaModel>
    {
        public ResetSenhaModelValidator()
        {
            RuleFor(signIn => signIn.Email).NotEmpty();
            RuleFor(signIn => signIn.NovaSenha).NotEmpty();
            RuleFor(signIn => signIn.Token).NotEmpty();
        }
    }
}
