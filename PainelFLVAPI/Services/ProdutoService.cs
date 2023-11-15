using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly FLVDbContext _FLVDbContext;

        public ProdutoService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public DtoListarProdutosResponse ObterTodosProdutos()
        {
            var response = new DtoListarProdutosResponse();
            var query = _FLVDbContext.Produto.ToList();

            var produtos = query.Select(x => new DtoListarProdutosResponse.Produto()
            {
                Id = x.Id,
                Categoria = x.Categoria,
                Nome = x.Nome
            }).ToList();
            
            response.Produtos = produtos;

            return response;
        }
    }
}
