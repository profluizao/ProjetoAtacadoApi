using Atacado.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaService servico;

        /// <summary>
        /// 
        /// </summary>
        public CategoriaController(AtacadoContext contexto) : base()
        {
            this.servico = new CategoriaService(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CategoriaPoco> GetAll()
        {
            return this.servico.Listar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public CategoriaPoco GetPorID(int id)
        {
            return this.servico.Selecionar(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public CategoriaPoco Post([FromBody] CategoriaPoco poco)
        {
            return this.servico.Criar(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public CategoriaPoco Put([FromBody] CategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public CategoriaPoco Delete([FromBody] CategoriaPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public CategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}

