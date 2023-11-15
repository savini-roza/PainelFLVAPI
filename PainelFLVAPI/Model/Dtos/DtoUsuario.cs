namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoObterUsuarioResponse : DtoResponseBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public sbyte Ativo { get; set; }
        public char TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? UrlFoto { get; set; }
    }

    public sealed class DtoCadastrarUsuarioRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public char TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public sealed class DtoCadastrarUsuarioResponse : DtoResponseBase
    {

    }

    public sealed class DtoAlterarUsuarioRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string? UrlFoto { get; set; }
    }

    public sealed class DtoAlterarUsuarioResponse : DtoResponseBase
    {

    }

    public sealed class DtoAlterarSenhaRequest
    {
        public string SenhaAtual { get ; set; }
        public string SenhaNova { get; set; }
        public string ConfirmarSenha { get; set; }
    }

    public sealed class DtoLogarRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
