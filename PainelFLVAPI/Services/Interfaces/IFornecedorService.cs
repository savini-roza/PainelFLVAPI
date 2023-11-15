using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface IFornecedorService
    {
        DtoObterFornecedorResponse ObterFornecedor(int id);
        Task<DtoCadastrarFornecedorResponse> CadastrarFornecedor(DtoCadastrarFornecedorRequest dto);
        DtoObterEmbalagensFornecedorResponse ObterEmbalagensFornecedor(int idFornecedor);
        DtoObterAvaliacoesFornecedorResponse ObterAvaliacoesFornecedor(int idFornecedor);
    }
}
