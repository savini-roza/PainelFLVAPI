using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class ContatoService : IContatoService
    {
        private readonly FLVDbContext _FLVDbContext;

        public ContatoService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        private DtoObterContatosCompradorResponse ObterContatosComprador(int idComprador)
        {
            var response = new DtoObterContatosCompradorResponse();

            var contatos = _FLVDbContext.ContatoCompradorProdutor.Where(x => x.IdComprador == idComprador).ToList();

            return response;
        }
    }
}
