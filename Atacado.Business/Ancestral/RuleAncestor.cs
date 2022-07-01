﻿namespace Atacado.Business.Ancestral
{
    public abstract class RuleAncestor<TPoco> : IRule where TPoco : class
    {
        protected List<string> ruleMessages;
        protected TPoco poco;

        public List<string> RuleMessages => this.ruleMessages;

        public TPoco Poco
        { 
            set => this.poco = value;
        }

        public RuleAncestor()
        {
            this.ruleMessages = new List<string>();
        }

        public RuleAncestor(TPoco poco)
        { 
            this.ruleMessages = new List<string>();
            this.poco = poco;
        }

        public virtual bool Process()
        {
            throw new NotImplementedException();
        }
    }
}
