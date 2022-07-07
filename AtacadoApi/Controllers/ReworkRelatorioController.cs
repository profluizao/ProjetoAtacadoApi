using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReworkRelatorioController : ControllerBase
    {
        private RelatorioService service;

        /// <summary>
        /// 
        /// </summary>
        public ReworkRelatorioController() : base()
        {
            this.service = new RelatorioService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpGet("{idCategoria:int}")]
        public ActionResult<List<RelatorioPoco>> GetRelatorioCategoriaPorID(int idCategoria)
        {
            try
            {
                List<RelatorioPoco> resposta = this.service.CategoriaPorID(idCategoria);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
