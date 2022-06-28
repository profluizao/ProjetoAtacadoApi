using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class BancoService : BaseAncestralService<BancoPoco, Banco>
    {
        private BancoMapper mapConfig;

        private BancoRepository repositorio;

        public BancoService()
        {
            this.mapConfig = new BancoMapper();
            this.repositorio = new BancoRepository(new AtacadoContext());
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
            return listDOM.Select(dom => this.mapConfig.Mapper.Map<BancoPoco>(dom)).ToList();
        }
    }
}
