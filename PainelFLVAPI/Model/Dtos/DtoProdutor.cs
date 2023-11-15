namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoObterProdutorResponse : DtoResponseBase
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
        public double? MediaAvaliacao { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
    }
    public sealed class DtoCadastrarProdutorRequest
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }

    }

    public class DtoCadastrarProdutorResponse : DtoResponseBase
    {

    }

    public sealed class DtoObterAvaliacoesProdutorResponse : DtoResponseBase
    {
        public IList<AvaliacaoProdutor> AvaliacoesProdutor { get; set; }
        public sealed class AvaliacaoProdutor
        {
            public int IdAvaliacao { get; set; }
            public int IdProdutor { get; set; }
            public int IdComprador { get; set; }
            public double Nota { get; set; }
            public string Comentario { get; set; }
            public string Resposta { get; set; }
            public DateTime DataComentario { get; set; }
            public DateTime DataResposta { get; set; }
        }
    }
}
