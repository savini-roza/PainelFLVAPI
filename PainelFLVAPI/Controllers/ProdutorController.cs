using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/produtor")]
    public class ProdutorController : ControllerBase
    {
        private readonly IProdutorService _produtorService;

        public ProdutorController(IProdutorService produtorService)
        {
            _produtorService = produtorService;
        }

        [HttpGet]
        [Route("/obter-produtor/{id}")]
        public ActionResult<DtoObterProdutorResponse> ObterProdutor(int id)
        {
            var usuario = _produtorService.ObterProdutor(id);
            return Ok(usuario);
        }

        [HttpPost]
        [Route("/cadastrar-produtor")]
        public async Task<ActionResult<DtoCadastrarProdutorResponse>> CadastrarProdutor(DtoCadastrarProdutorRequest produtor)
        {
            try
            {
                var novoProdutor = _produtorService.CadastrarProdutor(produtor);
                return Ok(novoProdutor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/cadastrar-produto-produtor")]
        public async Task<ActionResult<DtoSalvarProdutoProdutorResponse>> CadastrarProdutoProdutor(DtoSalvarProdutoProdutorRequest dto)
        {
            try
            {
                await _produtorService.AdicionarProdutosProdutor(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/editar-produto-produtor")]
        public async Task<ActionResult<DtoSalvarProdutoProdutorResponse>> EditarProdutoProdutor(DtoSalvarProdutoProdutorRequest dto)
        {
            try
            {
                await _produtorService.EditarProdutosProdutor(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/excluir-produto-produtor")]
        public async Task<ActionResult<DtoExcluirProdutoProdutorResponse>> ExcluirProdutoProdutor(DtoExcluirProdutoProdutorRequest dto)
        {
            try
            {
                await _produtorService.ExcluirProdutoProdutor(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/obter-produtos-produtor/{id}")]
        public ActionResult<DtoObterProdutosProdutorResponse> ObterProdutosProdutor(int id)
        {
            try
            {
                var produtos = _produtorService.ObterProdutosProdutor(id);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/obter-avaliacoes-produtor/{id}")]
        public ActionResult<DtoObterAvaliacoesProdutorResponse> ObterAvaliacoesProdutor(int id)
        {
            try
            {
                var avaliacoes = _produtorService.ObterAvaliacoesProdutor(id);
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}