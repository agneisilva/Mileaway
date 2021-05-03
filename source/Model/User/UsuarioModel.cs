namespace Architecture.Model
{
    public sealed record UsuarioModel
    {
        public long Id { get; init; }

        public string Nome { get; init; }

        public string Sobrenome { get; init; }

        public string Email { get; init; }

        public AuthModel Auth { get; init; }
    }
}
