

using Atacado.EF.Database;
using Atacado.Repository.Ancestral;

namespace Atacado.Repository.RH
{
    public class EmpresaRepository : BaseRepository<Empresa>
    {
        public EmpresaRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Empresa DeleteById(int id)
        {
            Empresa del = this.Read(id);
            this.context.Set<Empresa>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
