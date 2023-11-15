using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface IProdutoService
    {
        DtoListarProdutosResponse ObterTodosProdutos();
    }
}
