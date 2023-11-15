using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
     
        [HttpGet]
        [Route("/obter-usuario/{id}")]
        public ActionResult<DtoObterUsuarioResponse> ObterUsuario(int id)
        {
            var usuario = _usuarioService.ObterUsuario(id);
            return Ok(usuario);
        }

        [HttpPost]
        [Route("/cadastrar-usuario")]
        public async Task<ActionResult<DtoCadastrarUsuarioResponse>> CadastrarUsuario(DtoCadastrarUsuarioRequest usuario)
        {
            try
            {
                var novoUsuario = await _usuarioService.CadastrarUsuario(usuario);
                return Ok(novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("/alterar-usuario")]
        public async Task<ActionResult<DtoAlterarUsuarioResponse>> AlterarUsuario(DtoAlterarUsuarioRequest usuario)
        {
            try
            {
                await _usuarioService.AlterarUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}