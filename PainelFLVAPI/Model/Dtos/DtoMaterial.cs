namespace PainelFLVAPI.Model.Dtos
{
    public sealed class DtoListarMateriaisResponse : DtoResponseBase
    {
        public IList<Material> Materiais { get; set; }
        public sealed class Material
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }
    }
}
