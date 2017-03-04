using System;
using System.Collections.Generic;
using Inversion.Process.Architect;
using Inversion.Process.Behaviour;

namespace Inversion.Process.Architect.Examples.Behaviour
{
    public class ConsoleWriteBehaviour : TaoBehaviour
    {
        public ConsoleWriteBehaviour(string respondsTo) : base(respondsTo)
        {
            this.InitialisePraxis();
        }

        public ConsoleWriteBehaviour(string respondsTo, IPrototype prototype) : base(respondsTo, prototype)
        {
            this.InitialisePraxis();
        }

        public ConsoleWriteBehaviour(string respondsTo, IEnumerable<IConfigurationElement> config) : base(respondsTo, config)
        {
            this.InitialisePraxis();
        }

        public override void Action(IEvent ev, IProcessContext context)
        {
            string message = this.GetNameWithAssert("config", "message");

            Console.WriteLine(message);
        }

        protected override void InitialisePraxis()
        {
            this.Praxis["config"].Add("message");
        }
    }
}