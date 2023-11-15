using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/comprador")]
    public class CompradorController : ControllerBase
    {
        private readonly ICompradorService _compradorService;

        public CompradorController(ICompradorService compradorService)
        {
            _compradorService = compradorService;
        }

        [HttpGet]
        [Route("/obter-comprador/{id}")]
        public ActionResult<DtoObterCompradorResponse> ObterComprador(int id)
        {
            var comprador = _compradorService.ObterComprador(id);
            return Ok(comprador);
        }

        [HttpPost]
        [Route("/cadastrar-comprador")]
        public async Task<ActionResult<DtoCadastrarCompradorResponse>> CadastrarComprador(DtoCadastrarCompradorRequest dto)
        {
            try
            {
                var novoComprador = _compradorService.CadastrarComprador(dto);
                return Ok(novoComprador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/cadastrar-produto-comprador")]
        public async Task<ActionResult<DtoSalvarProdutoCompradorResponse>> CadastrarProdutoProdutor(DtoSalvarProdutoCompradorRequest dto)
        {
            try
            {
                await _compradorService.AdicionarProdutosComprador(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/excluir-produto-comprador")]
        public async Task<ActionResult<DtoSalvarProdutoCompradorResponse>> ExcluirProdutoProdutor(DtoSalvarProdutoCompradorRequest dto)
        {
            try
            {
                await _compradorService.ExcluirProdutoComprador(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("/obter-produtos-comprador/{id}")]
        //public ActionResult<DtoObterProdutosProdutorResponse> ObterProdutosProdutor(int id)
        //{
        //    try
        //    {
        //        var produtos = _compradorService.(id);
        //        return Ok(produtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}