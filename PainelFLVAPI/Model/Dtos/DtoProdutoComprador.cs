namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoSalvarProdutoCompradorRequest
    {
        public int IdComprador { get; set; }
        public int IdProduto { get; set; }
    }

    public sealed class DtoSalvarProdutoCompradorResponse : DtoResponseBase
    {

    }
}
