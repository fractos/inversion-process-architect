using System;
using System.Collections.Generic;

using Inversion.Process.Behaviour;
using Inversion.Web.Behaviour;

namespace Inversion.Process.Architect
{
    public abstract class TaoWebBehaviour : PrototypedWebBehaviour
    {
        // define expected services
        // define expected context members (parameters, control-state members, flags)
        // define expected configuration values
        // define emitted messages

        public IDictionary<string, IList<string>> Praxis = TaoBase.BasePraxis;

        protected TaoWebBehaviour(string respondsTo) : base(respondsTo) { }
        protected TaoWebBehaviour(string respondsTo, IPrototype prototype) : base(respondsTo, prototype) { }
        protected TaoWebBehaviour(string respondsTo, IEnumerable<IConfigurationElement> config) : base(respondsTo, config) { }

        protected abstract void InitialisePraxis();

        protected string GetOverride(string name)
        {
            return this.Praxis.GetOverride(this.Configuration, name);
        }

        protected string GetNameWithAssert(string frame, string slot)
        {
            return this.Praxis.GetNameWithAssert(this.Configuration, frame, slot);
        }
    }
}