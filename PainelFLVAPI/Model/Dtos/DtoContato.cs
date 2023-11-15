namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoObterContatosCompradorResponse : DtoResponseBase
    {

        public int IdComprador { get; set; }
        public string NomeProdutor { get; set; }
        public DateTime DataContato { get; set; }
        public string Mensagem { get; set; }
    }

    public sealed class DtoObterContatosProdutorFornecedorResponse : DtoResponseBase
    {
        public int IdProdutor { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime DataContato { get; set; }
        public string Mensagem { get; set; }
    }

    public sealed class DtoObterContatosProdutorCompradorResponse : DtoResponseBase
    {
        public int IdProdutor { get; set; }
        public string NomeComprador { get; set; }
        public DateTime DataContato { get; set; }
        public string Mensagem { get; set; }
    }

    public sealed class DtoAdicionarContatoCompradorProdutorRequest
    {
        public int IdComprador { get; set; }
        public int IdProdutor { get; set; }
        public string Mensagem { get; set; }
    }

    public sealed class DtoAdicionarContatoCompradorProdutorResponse : DtoResponseBase
    {

    }

    public sealed class DtoAdicionarContatoProdutorFornecedorRequest
    {
        public int IdProdutor { get; set; }
        public int IdFornecedor { get; set; }
        public string Mensagem { get; set; }
    }

    public sealed class DtoAdicionarContatoProdutorFornecedorResponse : DtoResponseBase
    {

    }
}