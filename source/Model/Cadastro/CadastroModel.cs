namespace Architecture.Cadastro
{
    public sealed record CadastroModel
    {
        public long Id { get; init; }
        
        public string IdentificadorCadastro { get; init; }
    }
}
