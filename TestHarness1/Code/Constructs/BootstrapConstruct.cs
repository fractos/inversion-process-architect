using System.Collections.Generic;
using Inversion.Process;
using Inversion.Process.Architect;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace TestHarness1.Constructs
{
    public class BootstrapConstruct : Construct
    {
        public BootstrapConstruct(Settings settings) : base("bootstrap", settings)
        {
            this.Behaviours = new List<IProcessBehaviour>
            {
                new SetFlagBehaviour(this.Message,
                    new Configuration.Builder
                    {
                        {"config", "set", "hello"},
                        {"config", "set", this.Settings["world"] }
                    })
            };
        }
    }
}