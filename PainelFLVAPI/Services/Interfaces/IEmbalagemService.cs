using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface IEmbalagemService
    {
        Task<DtoSalvarEmbalagemFornecedorResponse> AdicionarEmbalagens(DtoSalvarEmbalagemFornecedorRequest dto);
        Task<DtoEditarEmbalagemFornecedorResponse> EditarEmbalagem(DtoEditarEmbalagemFornecedorRequest dto);
        Task<DtoExcluirEmbalagemFornecedorResponse> ExcluirEmbalagemFornecedor(int id);
    }
}
