using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class CompradorService : ICompradorService
    {
        private readonly FLVDbContext _FLVDbContext;

        public CompradorService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public DtoObterCompradorResponse ObterComprador(int id)
        {
            var response = new DtoObterCompradorResponse();
            try
            {
                var queryComprador = _FLVDbContext.Comprador.SingleOrDefault(u => u.Id == id);

                var usuario = _FLVDbContext.Usuario.First(x => x.Id == queryComprador.IdUsuario);

                response.Id = queryComprador.Id;
                response.IdUsuario = queryComprador.IdUsuario;
                response.Nome = queryComprador.Nome;
                response.Telefone = usuario.Telefone;
                response.Cidade = usuario.Cidade;
                response.Estado = usuario.Estado;
                response.Logradouro = usuario.Logradouro;
                response.Complemento = usuario.Complemento;
                response.Bairro = usuario.Bairro;
                response.Numero = usuario.Numero;
                response.CNPJ = queryComprador.CNPJ;

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível obter o comprador";
            }
            return response;
        }

        public async Task<DtoCadastrarCompradorResponse> CadastrarComprador(DtoCadastrarCompradorRequest dto)
        {
            var response = new DtoCadastrarCompradorResponse();

            var comprador = new Comprador()
            {
                IdUsuario = dto.IdUsuario,
                Nome = dto.Nome,
                CNPJ = dto.CNPJ
            };

            try
            {
                _FLVDbContext.Comprador.Add(comprador);
                await _FLVDbContext.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch (Exception)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível cadastrar o comprador!";
            }
            return response;
        }

        public async Task<DtoSalvarProdutoCompradorResponse> AdicionarProdutosComprador(DtoSalvarProdutoCompradorRequest dto)
        {
            var response = new DtoSalvarProdutoCompradorResponse();

                var novoProduto = new ProdutoComprador
                {
                    IdProduto = dto.IdProduto,
                    IdComprador = dto.IdComprador,
                };

            try
            {
                _FLVDbContext.ProdutoComprador.Add(novoProduto);
                await _FLVDbContext.SaveChangesAsync();

                response.Sucesso = true;

                
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível adicionar o produto ao comprador.";
            }
            return response;
        }

        public async Task<DtoSalvarProdutoCompradorResponse> ExcluirProdutoComprador(DtoSalvarProdutoCompradorRequest dto)
        {
            var response = new DtoSalvarProdutoCompradorResponse();

            var produtoExistente = _FLVDbContext.ProdutoComprador.First(x => x.IdProduto == dto.IdProduto && x.IdComprador == dto.IdComprador);

            try
            {
                _FLVDbContext.ProdutoComprador.Remove(produtoExistente);
                await _FLVDbContext.SaveChangesAsync();

                response.Sucesso = true;


            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível excluir o produto.";
            }

            return response;
        }
    }
}
