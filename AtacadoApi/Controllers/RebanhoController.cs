using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Rebanho.
    /// </summary>
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private RebanhoService servico;

        /// <summary>
        /// 
        /// </summary>
        public RebanhoController(AtacadoContext contexto)
        {
            this.servico = new RebanhoService(contexto);
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a quantidade(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<RebanhoPoco>> Get(int skip, int take)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a busca por um único registro, usando a chave primária.
        /// </summary>
        /// <param name="id">Chave Primária do Registro.</param>
        /// <returns>Registro encontrado.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<RebanhoPoco> GetPorId(int id)
        {
            try
            {
                RebanhoPoco poco = this.servico.Selecionar(id);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }            
        }

        /// <summary>
        /// Realiza a busca por registros, passando o Ano Referência e o ID do Munícipio.
        /// </summary>
        /// <param name="anoRef">Ano Referência</param>
        /// <param name="idMun">ID do Munícipio</param>
        /// <returns></returns>
        [HttpGet("anoref/{anoRef:int}/idmun/{idMun:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorAnoRefIdMun(int anoRef, int idMun)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.FiltrarPorAnoRefIdMun(anoRef,idMun);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Cria um novo registro no recurso.
        /// </summary>
        /// <param name="poco">Instância que será criada.</param>
        /// <returns>Instância criada.</returns>
        [HttpPost]
        public ActionResult<RebanhoPoco> Post([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco pocoResposta = this.servico.Criar(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Altera um registro no recurso.
        /// </summary>
        /// <param name="poco">Registro que será alterado.</param>
        /// <returns>Registro alterado.</returns>
        [HttpPut]
        public ActionResult<RebanhoPoco> Put([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco pocoResposta = this.servico.Atualizar(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui um registro do recurso.
        /// </summary>
        /// <param name="poco">Registro a ser excluído</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete]
        public ActionResult<RebanhoPoco> Delete([FromBody] RebanhoPoco poco)
        {
            return this.DeletePorId(poco.IdRebanho);
        }

        /// <summary>
        /// Exclui um registro do recurso.
        /// </summary>
        /// <param name="id">ID do registro que será excluído.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult<RebanhoPoco> DeletePorId(int id)
        {
            try
            {
                RebanhoPoco pocoResposta = this.servico.Excluir(id);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
