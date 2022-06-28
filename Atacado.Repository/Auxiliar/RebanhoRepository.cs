using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class RebanhoRepository : BaseRepository<Rebanho>
    {
        public RebanhoRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Rebanho DeleteById(int id)
        {
            Rebanho del = this.Read(id);
            this.context.Set<Rebanho>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
