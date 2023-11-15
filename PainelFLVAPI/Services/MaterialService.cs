using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly FLVDbContext _FLVDbContext;

        public MaterialService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public DtoListarMateriaisResponse ObterTodosMateriais()
        {
            var response = new DtoListarMateriaisResponse();

            var listaEmbalagens = new List<Embalagem>();
            var query = _FLVDbContext.Material.ToList();

            var materiais = query.Select(x => new DtoListarMateriaisResponse.Material()
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();

            response.Materiais = materiais;

            return response;
        }
    }
}
