using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;

namespace PainelFLVAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        DtoObterUsuarioResponse ObterUsuario(int id);

        Task<DtoCadastrarUsuarioResponse> CadastrarUsuario(DtoCadastrarUsuarioRequest usuario);
        Task<DtoAlterarUsuarioResponse> AlterarUsuario(DtoAlterarUsuarioRequest dto);
    }
}
