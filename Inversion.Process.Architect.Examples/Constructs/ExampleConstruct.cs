﻿using System.Collections.Generic;
using Inversion.Process.Architect;
using Inversion.Process.Architect.Examples.Behaviour;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace Inversion.Process.Architect.Examples.Constructs
{
    public class ExampleConstruct : Construct
    {
        public ExampleConstruct(Settings settings) : base("example", settings)
        {
            this.Behaviours = new List<IProcessBehaviour>
            {
                new ExampleBehaviour(this.Message,
                    new Configuration.Builder
                    {
                        {"config", "output-key", "user"},
                        {"config", "emit-this-message", "user-loaded" }
                    }),

                new ConsoleWriteBehaviour("user-loaded",
                    new Configuration.Builder
                    {
                        {"config", "message", "user-loaded event fired" }
                    })
            };
        }
    }
}