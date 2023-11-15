using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface IProdutorService
    {
        DtoObterProdutorResponse ObterProdutor(int id);
        Task<DtoCadastrarProdutorResponse> CadastrarProdutor(DtoCadastrarProdutorRequest dto);
        Task<DtoSalvarProdutoProdutorResponse> AdicionarProdutosProdutor(DtoSalvarProdutoProdutorRequest dto);
        Task<DtoSalvarProdutoProdutorResponse> EditarProdutosProdutor(DtoSalvarProdutoProdutorRequest dto);
        Task<DtoExcluirProdutoProdutorResponse> ExcluirProdutoProdutor(DtoExcluirProdutoProdutorRequest dto);
        DtoObterProdutosProdutorResponse ObterProdutosProdutor(int idProdutor);
        DtoObterAvaliacoesProdutorResponse ObterAvaliacoesProdutor(int idProdutor);
    }
}
