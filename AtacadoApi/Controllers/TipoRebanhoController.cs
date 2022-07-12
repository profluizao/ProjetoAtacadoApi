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
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {
        private TipoRebanhoService servico;

        /// <summary>
        /// 
        /// </summary>
        public TipoRebanhoController(AtacadoContext contexto) : base()
        {
            this.servico = new TipoRebanhoService(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("{skip:int}/{take:int}")]
        public List<TipoRebanhoPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public TipoRebanhoPoco GetPorID(int id)
        {
            return this.servico.Selecionar(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public TipoRebanhoPoco Post([FromBody] TipoRebanhoPoco poco)
        {
            return this.servico.Criar(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public TipoRebanhoPoco Put([FromBody] TipoRebanhoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public TipoRebanhoPoco Delete([FromBody] TipoRebanhoPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public TipoRebanhoPoco DeletePorID(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
