using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly FLVDbContext _FLVDbContext;

        public FornecedorService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public DtoObterFornecedorResponse ObterFornecedor(int id)
        {
            var response = new DtoObterFornecedorResponse();
            try
            {
                var queryFornecedor = _FLVDbContext.Fornecedor.SingleOrDefault(u => u.Id == id);

                var usuario = _FLVDbContext.Usuario.First(x => x.Id == queryFornecedor.IdUsuario);

                response.Id = queryFornecedor.Id;
                response.IdUsuario = queryFornecedor.IdUsuario;
                response.Nome = queryFornecedor.Nome;
                response.Cidade = queryFornecedor.Cidade;
                response.Estado = queryFornecedor.Estado;
                response.Telefone = usuario.Telefone;
                response.Cidade = usuario.Cidade;
                response.Estado = usuario.Estado;
                response.Logradouro = usuario.Logradouro;
                response.Complemento = usuario.Complemento;
                response.Bairro = usuario.Bairro;
                response.Numero = usuario.Numero;
                response.CNPJ = queryFornecedor.CNPJ;

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível obter o fornecedor";
            }
            return response;
        }

        public async Task<DtoCadastrarFornecedorResponse> CadastrarFornecedor(DtoCadastrarFornecedorRequest dto)
        {
            var response = new DtoCadastrarFornecedorResponse();

            var fornecedor = new Fornecedor()
            {
                IdUsuario = dto.IdUsuario,
                Nome = dto.Nome,

                CNPJ = dto.CNPJ
            };

            try
            {
                _FLVDbContext.Fornecedor.Add(fornecedor);
                await _FLVDbContext.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch (Exception)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível cadastrar o fornecedor!";
            }
            return response;
        }

        public DtoObterEmbalagensFornecedorResponse ObterEmbalagensFornecedor(int idFornecedor)
        {
            var response = new DtoObterEmbalagensFornecedorResponse();

            var embalagens = _FLVDbContext.Embalagem
                .Where(x => x.IdFornecedor == idFornecedor).ToList();

            response.Embalagens = embalagens.Select(x => new DtoObterEmbalagensFornecedorResponse.EmbalagemFornecedor()
            {
                IdFornecedor = x.IdFornecedor,
                Nome = x.Nome,
                NomeMaterial = _FLVDbContext.Material.First(m => m.Id == x.IdMaterial).Nome,
                Capacidade = x.Capacidade,
                Dimensoes = x.Dimensoes,
                Unidade = x.Unidade
            }).ToList();

            return response;
        }

        public DtoObterAvaliacoesFornecedorResponse ObterAvaliacoesFornecedor(int idFornecedor)
        {
            var response = new DtoObterAvaliacoesFornecedorResponse();

            try
            {
                var query = _FLVDbContext.AvaliacaoProdutorFornecedor.Where(x => x.IdFornecedor == idFornecedor);


                if (query == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Não foram encontradas avaliações";

                    return response;
                }

                response.AvaliacoesFornecedor = query.Select(x => new DtoObterAvaliacoesFornecedorResponse.AvaliacaoFornecedor
                {
                    IdAvaliacao = x.Id,
                    IdFornecedor = x.IdFornecedor,
                    IdProdutor = x.IdProdutor,
                    Comentario = x.Comentario,
                    DataComentario = x.DataAvaliacao,
                    Nota = x.Nota,
                    Resposta = x.Resposta,
                    DataResposta = x.DataResposta
                }).ToList();

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível obter as avaliações.";
            }
            return response;
        }
    }
}
