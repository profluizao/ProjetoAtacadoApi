using Atacado.Business.Ancestral;

namespace Atacado.Business.RH
{
    public class TesteContrato : IContract
    {
        private bool isValidate;
        public bool IsValidate => this.isValidate;

        private List<IRule> rules;
        public List<IRule> Rules => this.rules;

        private List<string> messages;
        public List<string> Messages => this.messages;


        public TesteContrato()
        {
            this.isValidate = true;

            this.rules = new List<IRule>();
            this.rules.Add(new Teste01Regra());
            this.rules.Add(new Teste02Regra());
            this.rules.Add(new Teste03Regra());

            this.messages = new List<string>();
        }

        public bool Validate()
        {
            this.isValidate = true;

            foreach (IRule regra in this.rules)
            {
                if (regra.Process() == false)
                { 
                    this.messages.AddRange(regra.RuleMessages);
                    this.isValidate = false;
                }
            }

            return this.isValidate;
        }
    }
}
