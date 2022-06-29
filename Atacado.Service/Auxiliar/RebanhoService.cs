using Atacado.EF.Database;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;

namespace Atacado.Service.Auxiliar
{
    public class RebanhoService : BaseAncestralService<RebanhoPoco, Rebanho>
    {
        private RebanhoRepository repositorio;

        public RebanhoService()
        {
            this.mapeador = new MapeadorGenerico<RebanhoPoco, Rebanho>();
            this.repositorio = new RebanhoRepository(new AtacadoContext());
        }

        public List<RebanhoPoco> Listar(int pular, int exibir)
        {
            List<Rebanho> listDOM = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDOM);
        }

        public List<RebanhoPoco> FiltrarPorAnoRefIdMun(int anoRef, int idMun)
        {
            List<Rebanho> listDOM = 
                this.repositorio.Browse(reb => (reb.AnoRef == anoRef) && (reb.IdMunicipio == idMun)).ToList();
            return ProcessarListaDOM(listDOM);
        }

        protected override List<RebanhoPoco> ProcessarListaDOM(List<Rebanho> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<RebanhoPoco>(dom)).ToList();
        }

        public override RebanhoPoco Selecionar(int id)
        {
            Rebanho dom = this.repositorio.Read(id);
            RebanhoPoco poco = this.mapeador.Mecanismo.Map<RebanhoPoco>(dom);
            return poco;
        }

        public override RebanhoPoco Atualizar(RebanhoPoco obj)
        {
            Rebanho dom = this.mapeador.Mecanismo.Map<Rebanho>(obj);
            Rebanho alterado = this.repositorio.Edit(dom);
            RebanhoPoco poco = this.mapeador.Mecanismo.Map<RebanhoPoco>(alterado);
            return poco;
        }

        public override RebanhoPoco Criar(RebanhoPoco obj)
        {
            Rebanho dom = this.mapeador.Mecanismo.Map<Rebanho>(obj);
            Rebanho criado = this.repositorio.Add(dom);
            RebanhoPoco poco = this.mapeador.Mecanismo.Map<RebanhoPoco>(criado);
            return poco;
        }

        public override RebanhoPoco Excluir(int id)
        {
            Rebanho excluido = this.repositorio.DeleteById(id);
            RebanhoPoco poco = this.mapeador.Mecanismo.Map<RebanhoPoco>(excluido);
            return poco;
        }

        public override RebanhoPoco Excluir(RebanhoPoco obj)
        {
            return this.Excluir(obj.IdRebanho);
        }
    }
}
