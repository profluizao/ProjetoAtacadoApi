using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class IdiomaRepository : BaseRepository<Idioma>
    {
        public IdiomaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Idioma DeleteById(int id)
        {
            Idioma del = this.Read(id);
            this.context.Set<Idioma>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
