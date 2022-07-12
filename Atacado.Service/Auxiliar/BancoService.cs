using Atacado.EF.Database;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;

namespace Atacado.Service.Auxiliar
{
    public class BancoService : BaseAncestralService<BancoPoco, Banco>
    {
        private BancoRepository repositorio;

        public BancoService()
        {
            this.mapeador = new MapeadorGenerico<BancoPoco, Banco>();
            this.repositorio = new BancoRepository(new AtacadoContext());
        }

        public BancoService(AtacadoContext contexto)
        {
            this.mapeador = new MapeadorGenerico<BancoPoco, Banco>();
            this.repositorio = new BancoRepository(contexto);
        }

        public List<BancoPoco> Listar(int pular = 0, int exibir = 0)
        {
            List<Banco> listDOM;
            if (pular == 0)
            {
                listDOM = this.repositorio.Read().ToList();
            }
            else
            {
                listDOM = this.repositorio.Read(pular, exibir).ToList();
            }
            return this.ProcessarListaDOM(listDOM);
        }

        protected override List<BancoPoco> ProcessarListaDOM(List<Banco> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<BancoPoco>(dom)).ToList();
        }
    }
}
