using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class TipoAquiculturaRepository : BaseRepository<TipoAquicultura>
    {
        public TipoAquiculturaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override TipoAquicultura DeleteById(int id)
        {
            TipoAquicultura del = this.Read(id);
            this.context.Set<TipoAquicultura>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
