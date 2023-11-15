namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoObterFornecedorResponse : DtoResponseBase
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
        public double MediaAvaliacao { get; set; }
        public string CNPJ { get; set; }
    }
    public sealed class DtoCadastrarFornecedorRequest
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

    }

    public class DtoCadastrarFornecedorResponse : DtoResponseBase
    {

    }

    public sealed class DtoObterAvaliacoesFornecedorResponse : DtoResponseBase
    {
        public IList<AvaliacaoFornecedor> AvaliacoesFornecedor { get; set; }
        public sealed class AvaliacaoFornecedor
        {
            public int IdAvaliacao { get; set; }
            public int IdProdutor { get; set; }
            public int IdFornecedor { get; set; }
            public double Nota { get; set; }
            public string Comentario { get; set; }
            public string Resposta { get; set; }
            public DateTime DataComentario { get; set; }
            public DateTime DataResposta { get; set; }
        }
    }
}
