using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {
        private TipoRebanhoService servico;

        public TipoRebanhoController() : base()
        {
            this.servico = new TipoRebanhoService();
        }

        [HttpGet("{skip:int}/{take:int}")]
        public List<TipoRebanhoPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        [HttpGet("{id:int}")]
        public TipoRebanhoPoco GetPorID(int id)
        {
            return this.servico.Selecionar(id);
        }

        [HttpPost]
        public TipoRebanhoPoco Post([FromBody] TipoRebanhoPoco poco)
        {
            return this.servico.Criar(poco);
        }

        [HttpPut]
        public TipoRebanhoPoco Put([FromBody] TipoRebanhoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        [HttpDelete]
        public TipoRebanhoPoco Delete([FromBody] TipoRebanhoPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        [HttpDelete("{id:int}")]
        public TipoRebanhoPoco DeletePorID(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
