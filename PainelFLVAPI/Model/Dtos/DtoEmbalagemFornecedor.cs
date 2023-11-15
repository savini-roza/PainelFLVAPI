namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoObterEmbalagensFornecedorRequest
    {

    }

    public sealed class DtoObterEmbalagensFornecedorResponse
    {
        public IList<EmbalagemFornecedor> Embalagens { get; set; }
        public sealed class EmbalagemFornecedor
        {
            public int IdFornecedor { get; set; }
            public string Nome { get; set; }
            public string Capacidade { get; set; }
            public string Unidade { get; set; }
            public string Dimensoes { get; set; }
            public string NomeMaterial { get; set; }
        }
    }

    public sealed class DtoSalvarEmbalagemFornecedorRequest
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Capacidade { get; set; }
        public string Unidade { get; set; }
        public string Dimensoes { get; set; }
        public int IdMaterial { get; set; }
    }

    public sealed class DtoSalvarEmbalagemFornecedorResponse : DtoResponseBase
    {

    }

    public sealed class DtoEditarEmbalagemFornecedorRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Capacidade { get; set; }
        public string Unidade { get; set; }
        public string Dimensoes { get; set; }
        public int IdMaterial { get; set; }
    }

    public sealed class DtoEditarEmbalagemFornecedorResponse : DtoResponseBase
    {

    }

    public sealed class DtoExcluirEmbalagemFornecedorResponse : DtoResponseBase
    {

    }
}
