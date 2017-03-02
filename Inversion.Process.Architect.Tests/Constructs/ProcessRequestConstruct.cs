using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace Inversion.Process.Architect.Tests.Constructs
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
                        {"fire", "dispatch"},
                        {"fire", "view-state"},
                        {"fire", "process-views"},
                        {"fire", "render"}
                    })
            };
        }
    }
}