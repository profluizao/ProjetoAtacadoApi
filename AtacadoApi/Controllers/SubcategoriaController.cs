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
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaService servico;

        /// <summary>
        /// 
        /// </summary>
        public SubcategoriaController(AtacadoContext contexto) : base()
        {
            this.servico = new SubcategoriaService(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("{skip:int}/{take:int}")]
        public List<SubcategoriaPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public SubcategoriaPoco GetPorID(int id)
        {
            return this.servico.Selecionar(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpGet("PorIdCategoria/{idCategoria:int}")]
        public List<SubcategoriaPoco> GetSubcategoriasPorIdCategoria(int idCategoria)
        {
            return this.servico.PesquisarPorCategoria(idCategoria);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public SubcategoriaPoco Post([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Criar(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public SubcategoriaPoco Put([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public SubcategoriaPoco Delete([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public SubcategoriaPoco DeletePorID(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
