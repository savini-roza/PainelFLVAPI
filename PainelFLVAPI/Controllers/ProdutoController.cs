using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;

        }
     
        [HttpGet]
        [Route("/obter-produtos-todos")]
        public ActionResult<DtoListarProdutosResponse> ObterTodosProdutos()
        {
            try
            {
                var produtos = _produtoService.ObterTodosProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       
    }
}