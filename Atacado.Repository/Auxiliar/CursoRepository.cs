using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class CursoRepository : BaseRepository<Curso>
    {
        public CursoRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Curso DeleteById(int id)
        {
            Curso del = this.Read(id);
            this.context.Set<Curso>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
