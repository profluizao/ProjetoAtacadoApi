using Atacado.Mapper.Ancestral;

namespace Atacado.Service.Ancestral
{
    public abstract class BaseEnvelopadaService<TPoco, TDom, TEnvelope>
        where TPoco : class
        where TDom : class
        where TEnvelope : class
    {
        protected MapeadorGenericoEnvelopado<TPoco, TDom, TEnvelope> mapeador;

        protected List<string> mensagensProcessamento;
        public List<string> MensagensProcessamento => this.mensagensProcessamento;

        public BaseEnvelopadaService()
        {
            this.mensagensProcessamento = new List<string>();
        }

        public virtual TEnvelope Selecionar(int id)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual List<TEnvelope> Listar()
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TEnvelope Criar(TPoco obj)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TEnvelope Atualizar(TPoco obj)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TEnvelope Excluir(TPoco obj)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        public virtual TEnvelope Excluir(int id)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }

        protected virtual List<TEnvelope> ProcessarListaDOM(List<TDom> listDOM)
        {
            throw new NotImplementedException("Deixa de ser preguiçoso!!!");
        }
    }
}
