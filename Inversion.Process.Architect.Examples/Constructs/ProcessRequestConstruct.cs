using System.Collections.Generic;
using Inversion.Process.Architect;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace Inversion.Process.Architect.Examples.Constructs
{
    public class ProcessRequestConstruct : Construct
    {
        public ProcessRequestConstruct(Settings settings) : base("process-request", settings)
        {
            this.Behaviours = new List<IProcessBehaviour>
            {
                new ParameterisedSequenceBehaviour(this.Message,
                    new Configuration.Builder {
                        {"fire", "bootstrap"},
                        {"fire", "parse-request"},
                        {"fire", "example"},
                        {"fire", "view-state"},
                        {"fire", "process-views"},
                        {"fire", "render"}
                    })
            };
        }
    }
}