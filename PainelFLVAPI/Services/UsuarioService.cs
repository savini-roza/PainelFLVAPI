using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Repositories.Contexts;
using PainelFLVAPI.Services.Interfaces;
using System.Linq;

namespace PainelFLVAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly FLVDbContext _FLVDbContext;

        public UsuarioService(FLVDbContext FLVDbContext)
        {
            _FLVDbContext = FLVDbContext;
        }

        public DtoObterUsuarioResponse ObterUsuario(int id)
        {

            var response = new DtoObterUsuarioResponse();

            try
            {
                var queryUsuario = _FLVDbContext.Usuario.SingleOrDefault(u => u.Id == id);

                response.Id = queryUsuario.Id;
                response.Email = queryUsuario.Email;
                response.Ativo = queryUsuario.Ativo;
                response.DataCadastro = queryUsuario.DataCadastro;
                response.TipoUsuario = queryUsuario.TipoUsuario;
                response.UrlFoto = queryUsuario.UrlFoto;

                response.Sucesso = true;
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possível obter o usuário";
            }

            return response;
        }

        public async Task<DtoCadastrarUsuarioResponse> CadastrarUsuario(DtoCadastrarUsuarioRequest usuario)
        {
            var response = new DtoCadastrarUsuarioResponse();
            var usuarioExistente = VerificarUsuarioExistente(usuario.Email);
            if (usuarioExistente)
            {
                response.Mensagem = "O usuário já existe.";
                response.Sucesso = false;
                return response;
            }

            if (!VerificarConfirmarSenha(usuario.Senha, usuario.ConfirmarSenha))
            {
                response.Mensagem = "As senhas não coincidem.";
                response.Sucesso = false;
                return response;
            }

            var novoUsuario = new Usuario()
            {
                Email = usuario.Email,
                Senha = CriptografarSenha(usuario.Senha),
                Ativo = 1,
                DataCadastro = DateTime.Today,
                TipoUsuario = usuario.TipoUsuario,
            };

            try
            {
                _FLVDbContext.Usuario.Add(novoUsuario);
                await _FLVDbContext.SaveChangesAsync();

                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
                return response;
            }
        }

        public async Task<DtoAlterarUsuarioResponse> AlterarUsuario(DtoAlterarUsuarioRequest dto)
        {
            var response = new DtoAlterarUsuarioResponse();

            try
            {
                var usuario = _FLVDbContext.Usuario.First(x => x.Id == dto.Id);
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
                return response;
            }

            return response;
        }

        private bool VerificarUsuarioExistente(string email)
        {
            var queryUsuario = _FLVDbContext.Usuario.AsQueryable()
                .Select(x => new Usuario()
                {
                    Email = x.Email
                })
                .Where(x => x.Email == email);

            var usuario = _FLVDbContext.Usuario.SingleOrDefault(u => u.Email == email);

            return usuario == null;
        }

        private string CriptografarSenha(string senha)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(senha);
            return passwordHash;
        }

        private bool VerificarConfirmarSenha(string senha, string confirmar)
        {
            return senha == confirmar;
        }

        private bool VerificarSenhaLogin(string senha, Usuario usuario)
        {
            bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
            return validPassword;
        }
    }
}
