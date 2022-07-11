using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class AquiculturaRepository : BaseRepository<Aquicultura>
    {
        public AquiculturaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Aquicultura DeleteById(int id)
        {
            Aquicultura del = this.Read(id);
            this.context.Set<Aquicultura>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
