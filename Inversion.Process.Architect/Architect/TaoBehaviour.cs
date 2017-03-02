using System;
using System.Collections.Generic;
using Inversion.Process.Behaviour;

namespace Inversion.Process.Architect
{
    public abstract class TaoBehaviour : PrototypedBehaviour
    {
        // define expected services
        // define expected context members (parameters, control-state members, flags)
        // define expected configuration values
        // define emitted messages
        
        protected TaoBehaviour(string respondsTo) : base(respondsTo)
        {
        }

        protected TaoBehaviour(string respondsTo, IPrototype prototype) : base(respondsTo, prototype)
        {
        }

        protected TaoBehaviour(string respondsTo, IEnumerable<IConfigurationElement> config) : base(respondsTo, config)
        {
        }

    }
}
