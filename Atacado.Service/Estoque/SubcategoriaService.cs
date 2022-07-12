using Atacado.Poco.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Service.Ancestral;
using Atacado.Repository.Estoque;

namespace Atacado.Service.Estoque
{
    public class SubcategoriaService : BaseAncestralService<SubcategoriaPoco, Subcategoria>
    {
        private SubcategoriaRepository repositorio;

        public SubcategoriaService()
        {
            this.mapeador = new Mapper.Ancestral.MapeadorGenerico<SubcategoriaPoco, Subcategoria>();
            this.repositorio = new SubcategoriaRepository(new AtacadoContext());
        }

        public SubcategoriaService(AtacadoContext contexto)
        {
            this.mapeador = new Mapper.Ancestral.MapeadorGenerico<SubcategoriaPoco, Subcategoria>();
            this.repositorio = new SubcategoriaRepository(contexto);
        }

        public override List<SubcategoriaPoco> Listar()
        {
            List<Subcategoria> listDOM = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDOM);
        }

        public List<SubcategoriaPoco> Listar(int pular, int exibir)
        {
            List<Subcategoria> listDOM = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDOM);
        }

        protected override List<SubcategoriaPoco> ProcessarListaDOM(List<Subcategoria> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<SubcategoriaPoco>(dom)).ToList();
        }

        public override SubcategoriaPoco Selecionar(int id)
        {
            Subcategoria dom = this.repositorio.Read(id);
            SubcategoriaPoco poco = this.mapeador.Mecanismo.Map<SubcategoriaPoco>(dom);
            return poco;
        }

        public override SubcategoriaPoco Criar(SubcategoriaPoco obj)
        {
            Subcategoria dom = this.mapeador.Mecanismo.Map<Subcategoria>(obj);
            Subcategoria criado = this.repositorio.Add(dom);
            SubcategoriaPoco poco = this.mapeador.Mecanismo.Map<SubcategoriaPoco>(criado);
            return poco;
        }

        public override SubcategoriaPoco Atualizar(SubcategoriaPoco obj)
        {
            Subcategoria dom = this.mapeador.Mecanismo.Map<Subcategoria>(obj);
            Subcategoria atualizado = this.repositorio.Edit(dom);
            SubcategoriaPoco poco = this.mapeador.Mecanismo.Map<SubcategoriaPoco>(atualizado);
            return poco;
        }

        public override SubcategoriaPoco Excluir(SubcategoriaPoco obj)
        {
            return this.Excluir(obj.IdSubcategoria);
        }

        public override SubcategoriaPoco Excluir(int id)
        {
            Subcategoria excluido = this.repositorio.DeleteById(id);
            SubcategoriaPoco poco = this.mapeador.Mecanismo.Map<SubcategoriaPoco>(excluido);
            return poco;
        }
    }
}
