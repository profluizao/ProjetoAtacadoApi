using Atacado.Envelope.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AtacadoApi.Controllers
{
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class AquiculturaController : ControllerBase
    {
        private AquiculturaService servico;

        /// <summary>
        /// 
        /// </summary>
        public AquiculturaController() : base()
        {
            this.servico = new AquiculturaService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<AquiculturaEnvelopeJSON>> Get(int skip, int take)
        {
            try
            {
                List<AquiculturaEnvelopeJSON> resposta = this.servico.Listar(skip, take);
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
        public ActionResult<AquiculturaEnvelopeJSON> GetPorId(int id)
        {
            try
            {
                AquiculturaEnvelopeJSON resposta = this.servico.Selecionar(id);
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
        public ActionResult<AquiculturaEnvelopeJSON> Post([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON resposta = this.servico.Criar(poco);
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
        public ActionResult<AquiculturaEnvelopeJSON> Put([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON resposta = this.servico.Atualizar(poco);
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
        public ActionResult<AquiculturaEnvelopeJSON> Delete([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON resposta = this.servico.Excluir(poco);
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
        public ActionResult<AquiculturaEnvelopeJSON> DeletePorId(int id)
        {
            try
            {
                AquiculturaEnvelopeJSON resposta = this.servico.Excluir(id);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
