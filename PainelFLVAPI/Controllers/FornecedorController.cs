using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;

        }
     
        [HttpGet]
        [Route("/obter-embalagens-fornecedor/{id}")]
        public ActionResult<DtoObterEmbalagensFornecedorResponse> ObterEmbalagensFornecedor(int id)
        {
            try
            {
                var embalagens = _fornecedorService.ObterEmbalagensFornecedor(id);
                return Ok(embalagens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/obter-avaliacoes-fornecedor/{id}")]
        public ActionResult<DtoObterAvaliacoesFornecedorResponse> ObterAvaliacoesFornecedor(int id)
        {
            try
            {
                var avaliacoes = _fornecedorService.ObterAvaliacoesFornecedor(id);
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}