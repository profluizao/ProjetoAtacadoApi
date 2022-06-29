using Atacado.Business.Ancestral;

namespace Atacado.Business.RH
{
    public class Teste01Regra : IRule
    {
        private List<string> ruleMessages;
        public List<string> RuleMessages => this.ruleMessages;

        public Teste01Regra()
        { 
            this.ruleMessages = new List<string>();
        }

        public bool Process()
        {
            bool retorno = true;

            if (this.Regra1() == false)
            {
                retorno = false;
            }
            if (this.Regra2() == false)
            {
                retorno = false;
            }
            if (this.Regra3() == false)
            {
                retorno = false;
            }
            if (this.Regra4() == false)
            {
                retorno = false;
            }
            if (this.Regra5() == false)
            {
                retorno = false;
            }
            return retorno;
        }

        private bool Regra1()
        {
            //Pior caso
            this.ruleMessages.Add("Regra falhou...");
            return false;
        }

        private bool Regra2()
        {
            //Pior caso
            this.ruleMessages.Add("Regra falhou...");
            return false;
        }

        private bool Regra3()
        {
            //Pior caso
            this.ruleMessages.Add("Regra falhou...");
            return false;
        }

        private bool Regra4()
        {
            //Pior caso
            this.ruleMessages.Add("Regra falhou...");
            return false;
        }

        private bool Regra5()
        {
            //Pior caso
            this.ruleMessages.Add("Regra falhou...");
            return false;
        }
    }
}
