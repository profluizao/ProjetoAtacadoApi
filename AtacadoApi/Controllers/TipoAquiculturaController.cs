using Atacado.EF.Database;
using Atacado.Envelope.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class TipoAquiculturaController : ControllerBase
    {
        private TipoAquiculturaService servico;

        /// <summary>
        /// 
        /// </summary>
        public TipoAquiculturaController(AtacadoContext contexto) : base()
        {
            this.servico = new TipoAquiculturaService(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<List<TipoAquiculturaEnvelopeJSON>> Get()
        {
            try
            {
                List<TipoAquiculturaEnvelopeJSON> resposta = this.servico.Listar();
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<TipoAquiculturaEnvelopeJSON> GetPorId(int id)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON resposta = this.servico.Selecionar(id);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Post([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON resposta = this.servico.Criar(poco);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Put([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON resposta = this.servico.Atualizar(poco);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Delete([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON resposta = this.servico.Excluir(poco);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult<TipoAquiculturaEnvelopeJSON> DeletePorId(int id)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON resposta = this.servico.Excluir(id);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
