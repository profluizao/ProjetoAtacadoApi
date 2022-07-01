using Atacado.Business.Ancestral;
using Atacado.Poco.RH;

namespace Atacado.Business.RH
{
    public class EmpresaRegra : RuleAncestor<EmpresaPoco>, IRule
    {
        public EmpresaRegra(EmpresaPoco poco) : base(poco)
        { }

        public override bool Process()
        {
            return base.Process();
        }
    }
}
