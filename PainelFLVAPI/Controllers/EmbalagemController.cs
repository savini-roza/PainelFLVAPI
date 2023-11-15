using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/embalagem")]
    public class EmbalagemController : ControllerBase
    {
        private readonly IEmbalagemService _embalagemService;

        public EmbalagemController(IEmbalagemService embalagemService)
        {
            _embalagemService = embalagemService;

        }
     
        [HttpPost]
        [Route("/salvar-embalagem/")]
        public async Task<ActionResult<DtoSalvarEmbalagemFornecedorResponse>> SalvarEmbalagens(DtoSalvarEmbalagemFornecedorRequest dto)
        {
            try
            {
                await _embalagemService.AdicionarEmbalagens(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("/editar-embalagem/")]
        public async Task<ActionResult<DtoEditarEmbalagemFornecedorResponse>> Editarmbalagens(DtoEditarEmbalagemFornecedorRequest dto)
        {
            try
            {
                await _embalagemService.EditarEmbalagem(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/excluir-embalagem/{id}")]
        public async Task<ActionResult<DtoExcluirEmbalagemFornecedorResponse>> ExcluirEmbalagens(int id)
        {
            try
            {
                await _embalagemService.ExcluirEmbalagemFornecedor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}