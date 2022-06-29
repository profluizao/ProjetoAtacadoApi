using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.RH
{
    public class FuncionarioRepository : BaseRepository<Funcionario>
    {
        public FuncionarioRepository(AtacadoContext contexto) : base(contexto)
        { }

        public override Funcionario DeleteById(int id)
        {
            Funcionario del = this.context.Set<Funcionario>().Find(id);
            this.context.Set<Funcionario>().Remove(del);
            this.context.SaveChanges();
            return del;
        }
    }
}
