using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace Inversion.Process.Architect.Examples.Constructs
{
    public class ParameterisedSequenceBehaviourConstruct : Construct
    {
        public ParameterisedSequenceBehaviourConstruct(Settings settings) : base("message", settings)
        {
            this.Behaviours = new List<IProcessBehaviour>
            {
                new ParameterisedSequenceBehaviour(this.Message, new Configuration.Builder {})
            };
        }
    }
}