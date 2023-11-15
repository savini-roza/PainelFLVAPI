using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface ICompradorService
    {
        DtoObterCompradorResponse ObterComprador(int id);
        Task<DtoCadastrarCompradorResponse> CadastrarComprador(DtoCadastrarCompradorRequest dto);
        Task<DtoSalvarProdutoCompradorResponse> AdicionarProdutosComprador(DtoSalvarProdutoCompradorRequest dto);
        Task<DtoSalvarProdutoCompradorResponse> ExcluirProdutoComprador(DtoSalvarProdutoCompradorRequest dto);
    }
}
