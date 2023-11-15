namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoObterCompradorResponse : DtoResponseBase
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CNPJ { get; set; }
    }
    public sealed class DtoCadastrarCompradorRequest
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

    }

    public class DtoCadastrarCompradorResponse : DtoResponseBase
    {

    }
}
