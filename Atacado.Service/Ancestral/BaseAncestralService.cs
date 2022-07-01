using Atacado.Mapper.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Ancestral
{
    public abstract class BaseAncestralService<TPoco, TDom> 
        where TPoco : class
        where TDom : class
    {
        protected MapeadorGenerico<TPoco, TDom> mapeador;

        protected List<string> mensagensProcessamento;

        public List<string> MensagensProcessamento => this.mensagensProcessamento;

        public BaseAncestralService()
        {
            this.mensagensProcessamento = new List<string>();
        }

        public virtual List<TPoco> Listar()
        { 
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TPoco Selecionar(int id)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TPoco Criar(TPoco obj)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TPoco Atualizar(TPoco obj)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TPoco Excluir(TPoco obj)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TPoco Excluir(int id)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        protected virtual List<TPoco> ProcessarListaDOM(List<TDom> listDOM)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }
    }
}
