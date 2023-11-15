using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class EmbalagemService : IEmbalagemService
    {
        private readonly FLVDbContext _FLVDbContext;

        public EmbalagemService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public async Task<DtoSalvarEmbalagemFornecedorResponse> AdicionarEmbalagens(DtoSalvarEmbalagemFornecedorRequest dto)
        {
            var response = new DtoSalvarEmbalagemFornecedorResponse();

                var novaEmbalagem = new Embalagem
                {
                    IdFornecedor = dto.IdFornecedor,
                    Nome = dto.Nome,
                    Capacidade = dto.Capacidade,
                    Unidade = dto.Unidade,
                    Dimensoes = dto.Dimensoes,
                    IdMaterial = dto.IdMaterial
                };

            try
            {
                _FLVDbContext.Embalagem.Add(novaEmbalagem);
                await _FLVDbContext.SaveChangesAsync();

                response.Sucesso = true;


            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível adicionar as embalagens.";
            }
            return response;
        }

        public async Task<DtoEditarEmbalagemFornecedorResponse> EditarEmbalagem(DtoEditarEmbalagemFornecedorRequest dto)
        {
            var response = new DtoEditarEmbalagemFornecedorResponse();

            var embalagemExistente = _FLVDbContext.Embalagem.First(x => x.Id == dto.Id);

            embalagemExistente.IdMaterial = dto.IdMaterial;
            embalagemExistente.Unidade = dto.Unidade;
            embalagemExistente.Nome = dto.Nome;
            embalagemExistente.Capacidade = dto.Capacidade;
            embalagemExistente.Dimensoes = dto.Dimensoes;

            try
            {
                _FLVDbContext.Embalagem.Update(embalagemExistente);
                await _FLVDbContext.SaveChangesAsync();

                response.Sucesso = true;


            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível editar a embalagem.";
            }

            return response;
        }

        public async Task<DtoExcluirEmbalagemFornecedorResponse> ExcluirEmbalagemFornecedor(int id)
        {
            var response = new DtoExcluirEmbalagemFornecedorResponse();

            var embalagemExistente = _FLVDbContext.Embalagem.First(x => x.Id == id);

            try
            {
                _FLVDbContext.Embalagem.Remove(embalagemExistente);
                await _FLVDbContext.SaveChangesAsync();

                response.Sucesso = true;


            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível excluir a embalagem.";
            }

            return response;
        }
    }
}
