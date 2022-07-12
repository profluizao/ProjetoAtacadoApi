using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioAquiculturaController : ControllerBase
    {
        private RelatorioAquiculturaService servico;

        /// <summary>
        /// 
        /// </summary>
        public RelatorioAquiculturaController(AtacadoContext contexto) : base()
        {
            this.servico = new RelatorioAquiculturaService(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMunicipio"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet("ConsultaPor/IdMunicipio/{idMunicipio:int}/Ano/{ano:int}")]
        public ActionResult<List<RelatorioAquiculturaPoco>> GetPorIdMunicipioAnoProducaoNaoNula(int idMunicipio, int ano)
        {
            try
            {
                List<RelatorioAquiculturaPoco> resposta = 
                    this.servico.PesquisarPorIdMunicipioAnoProducaoNaoNula(idMunicipio, ano);
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
        /// <param name="idTipoAquicultura"></param>
        /// <param name="ano"></param>
        /// <param name="idMunicipio"></param>
        /// <returns></returns>
        [HttpGet("ConsultaPor/IdTipoAquicultura/{idTipoAquicultura:int}/Ano/{ano:int}/IdMunicipio/{idMunicipio:int}")]
        public ActionResult<List<RelatorioAquiculturaPoco>> GetPorIdTipoAquiculturaAnoIdMunicipio(int idTipoAquicultura,
            int ano, int idMunicipio)
        {
            try
            {
                List<RelatorioAquiculturaPoco> resposta =
                    this.servico.PesquisarPorIdTipoAquiculturaAnoIdMunicipio(idTipoAquicultura, ano, idMunicipio);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
