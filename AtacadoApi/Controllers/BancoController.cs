using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private BancoService servico;

        public BancoController() : base()
        {
            this.servico = new BancoService();
        }

        [HttpGet]
        public List<BancoPoco> GetAll()
        {
            return this.servico.Listar();
        }
    }
}
