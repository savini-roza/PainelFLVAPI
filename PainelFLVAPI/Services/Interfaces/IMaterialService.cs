using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface IMaterialService
    {
        DtoListarMateriaisResponse ObterTodosMateriais();
    }
}
