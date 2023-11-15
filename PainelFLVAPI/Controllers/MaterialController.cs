using Microsoft.AspNetCore.Mvc;
using PainelFLVAPI.Model;
using PainelFLVAPI.Model.Dtos;
using PainelFLVAPI.Services;
using PainelFLVAPI.Services.Interfaces;

namespace PainelFLVAPI.Controllers
{
    [ApiController]
    [Route("api/material")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;

        }
     
        [HttpGet]
        [Route("/obter-materiais-todos")]
        public ActionResult<DtoListarMateriaisResponse> ObterTodosMateriais()
        {
            try
            {
                var materiais = _materialService.ObterTodosMateriais();
                return Ok(materiais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       
    }
}