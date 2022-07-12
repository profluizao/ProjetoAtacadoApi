using Atacado.EF.Database;
using Atacado.Envelope.RH;
using Atacado.Poco.RH;
using Atacado.Service.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/rh/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private EmpresaService servico;

        /// <summary>
        /// 
        /// </summary>
        public EmpresaController(AtacadoContext contexto) : base()
        { 
            this.servico = new EmpresaService(contexto);
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a quantidade(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<EmpresaEnvelopeJSON>> GetAll(int skip, int take)
        {
            try
            {
                List<EmpresaEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza a busca pela chave do registro.
        /// </summary>
        /// <param name="id">Chave do Registro</param>
        /// <returns>Resultado da busca</returns>
        [HttpGet("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> Get(int id)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Selecionar(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Cria um registro no recurso.
        /// </summary>
        /// <param name="poco">Registro que será criado.</param>
        /// <returns>Registro criado.</returns>
        [HttpPost]
        public ActionResult<EmpresaEnvelopeJSON> Post([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Criar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Atualiza um registro no recurso.
        /// </summary>
        /// <param name="poco">Registro que será atualizado.</param>
        /// <returns>Registro atualizado.</returns>
        [HttpPut]
        public ActionResult<EmpresaEnvelopeJSON> Put([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Atualizar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui um registro no recurso.
        /// </summary>
        /// <param name="poco">Registro que será excluído.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete]
        public ActionResult<EmpresaEnvelopeJSON> Delete([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Excluir(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui um registro no recurso, utilizando a chave do registro.
        /// </summary>
        /// <param name="id">Chave do registro.</param>
        /// <returns>Registro excluído.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> Delete(int id)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Excluir(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
