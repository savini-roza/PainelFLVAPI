using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class ProdutorService : IProdutorService
    {
        private readonly FLVDbContext _FLVDbContext;

        public ProdutorService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public DtoObterProdutorResponse ObterProdutor(int id)
        {
            var response = new DtoObterProdutorResponse();

            try
            {
                var queryProdutor = _FLVDbContext.Produtor.SingleOrDefault(u => u.Id == id);

                if (queryProdutor == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Não foi encontrado produtor";

                    return response;
                }

                var usuario = _FLVDbContext.Usuario.First(x => x.Id == queryProdutor.IdUsuario);

                response.Id = queryProdutor.Id;
                response.IdUsuario = queryProdutor.IdUsuario;
                response.Nome = queryProdutor.Nome;
                response.Telefone = usuario.Telefone;
                response.Cidade = usuario.Cidade;
                response.Estado = usuario.Estado;
                response.Logradouro = usuario.Logradouro;
                response.Complemento = usuario.Complemento;
                response.Bairro = usuario.Bairro;
                response.Numero = usuario.Numero;
                response.MediaAvaliacao = queryProdutor.MediaAvaliacao;
                response.CNPJ = queryProdutor.CNPJ;
                response.InscricaoEstadual = queryProdutor.InscricaoEstadual;

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível obter o produtor.";
            }
            return response;
        }

        public async Task<DtoCadastrarProdutorResponse> CadastrarProdutor(DtoCadastrarProdutorRequest dto)
        {
            var response = new DtoCadastrarProdutorResponse();

            var produtor = new Produtor()
            {
                IdUsuario = dto.IdUsuario,
                Nome = dto.Nome,
                CNPJ = dto.CNPJ,
                InscricaoEstadual = dto.InscricaoEstadual
            };

            try
            {
                _FLVDbContext.Produtor.Add(produtor);
                await _FLVDbContext.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível cadastrar o produtor";
            }

            return response;
        }

        public async Task<DtoSalvarProdutoProdutorResponse> AdicionarProdutosProdutor(DtoSalvarProdutoProdutorRequest dto)
        {
            var response = new DtoSalvarProdutoProdutorResponse();

                var novoProduto = new ProdutoProdutor
                {
                    IdProduto = dto.IdProduto,
                    IdProdutor = dto.IdProdutor,
                    Preco = dto.Preco,
                    Unidade = dto.Unidade
                };

            var produtoExistente = _FLVDbContext.ProdutoProdutor.First(x => x.IdProduto == dto.IdProduto && x.IdProdutor == dto.IdProdutor);

            if(produtoExistente != null)
            {
                response.Mensagem = "Produto já cadastrado!";
                response.Sucesso = false;
                return response;
            }

            try
            {
                await _FLVDbContext.ProdutoProdutor.AddAsync(novoProduto);
                await _FLVDbContext.SaveChangesAsync();
                response.Sucesso = true;
            }


            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível cadastrar os produtos";
            }
            return response;
        }

        public async Task<DtoSalvarProdutoProdutorResponse> EditarProdutosProdutor(DtoSalvarProdutoProdutorRequest dto)
        {
            var response = new DtoSalvarProdutoProdutorResponse();

            var produtoExistente = _FLVDbContext.ProdutoProdutor.First(x => x.IdProduto == dto.IdProduto && x.IdProdutor == dto.IdProdutor);

            produtoExistente.Preco = dto.Preco;
            produtoExistente.Unidade = dto.Unidade;

            try
            {
                _FLVDbContext.ProdutoProdutor.Update(produtoExistente);
                await _FLVDbContext.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível editar o produto";
            }

            return response;
        }

        public async Task<DtoExcluirProdutoProdutorResponse> ExcluirProdutoProdutor(DtoExcluirProdutoProdutorRequest dto)
        {
            var response = new DtoExcluirProdutoProdutorResponse();

            var produtoExistente = _FLVDbContext.ProdutoProdutor.First(x => x.IdProduto == dto.IdProduto && x.IdProdutor == dto.IdProdutor);

            try
            {
                _FLVDbContext.ProdutoProdutor.Remove(produtoExistente);
                await _FLVDbContext.SaveChangesAsync();
                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível excluir o produto";
            }

            return response;
        }
        public DtoObterProdutosProdutorResponse ObterProdutosProdutor(int idProdutor)
        {
            var response = new DtoObterProdutosProdutorResponse();

            try
            {
                var query = _FLVDbContext.ProdutoProdutor.Where(x => x.IdProdutor == idProdutor);


                if (query == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Não foram encontrados produtos";

                    return response;
                }

                response.ProdutosObtidos = query.Select(x => new DtoObterProdutosProdutorResponse.ProdutoObtido
                {
                    IdProduto = x.IdProduto,
                    IdProdutor = x.IdProdutor,
                    NomeProduto = _FLVDbContext.Produto.First(y => y.Id == x.IdProduto).Nome,
                    Preco = x.Preco,
                    Unidade = x.Unidade
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

        public DtoObterAvaliacoesProdutorResponse ObterAvaliacoesProdutor(int idProdutor)
        {
            var response = new DtoObterAvaliacoesProdutorResponse();

            try
            {
                var query = _FLVDbContext.AvaliacaoCompradorProdutor.Where(x => x.IdProdutor == idProdutor);


            if (query == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Não foram encontradas avaliações";

                    return response;
                }

                response.AvaliacoesProdutor = query.Select(x => new DtoObterAvaliacoesProdutorResponse.AvaliacaoProdutor
                {
                    IdAvaliacao = x.Id,
                    IdComprador = x.IdComprador,
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

