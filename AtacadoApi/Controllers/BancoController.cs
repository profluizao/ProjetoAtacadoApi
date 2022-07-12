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
    public class BancoController : ControllerBase
    {
        private BancoService servico;

        /// <summary>
        /// 
        /// </summary>
        public BancoController(AtacadoContext contexto) : base()
        {
            this.servico = new BancoService(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<BancoPoco> GetAll()
        {
            return this.servico.Listar();
        }
    }
}
