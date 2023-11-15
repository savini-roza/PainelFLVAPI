namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoSalvarProdutoProdutorRequest
    {
            public int IdProdutor { get; set; }
            public int IdProduto { get; set; }
            public string Unidade { get; set; }
            public double Preco { get; set; }
    }

    public sealed class DtoSalvarProdutoProdutorResponse : DtoResponseBase
    {

    }

    public sealed class DtoExcluirProdutoProdutorRequest
    {
        public int IdProdutor { get; set; }
        public int IdProduto { get; set; }
    }

    public sealed class DtoExcluirProdutoProdutorResponse : DtoResponseBase
    {

    }

    public sealed class DtoObterProdutosProdutorResponse : DtoResponseBase
    {
        public IList<ProdutoObtido> ProdutosObtidos { get; set; }
        public sealed class ProdutoObtido
        {
            public int IdProduto { get; set; }
            public int IdProdutor { get; set; }
            public string NomeProduto { get; set; }
            public string Unidade { get; set; }
            public double Preco { get; set; }
        }
    }
}
