namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoListarProdutosResponse : DtoResponseBase
    {
        public IList<Produto> Produtos { get; set; }
        public sealed class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public char Categoria { get; set; }
        }
    }
}
