﻿using System;
using System.Collections.Generic;

using Inversion.Data;
using Inversion.Process;
using Inversion.Process.Architect;
using Inversion.Process.Architect.Examples.Constructs;
using Inversion.Process.Architect.Examples.Data;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace TestHarness1
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceContainerRegistrar serviceContainer = Inversion.Naiad.ServiceContainer.Instance;

            Settings settings = new Settings(ConfigurationHelper.GetConfigurationFromConfig());

            IList<Construct> requestBehaviourConstructs = new List<Construct>
            {
                // plan for "process-request"
                new ProcessRequestConstruct(settings),

                // plan for "bootstrap"
                new BootstrapConstruct(settings),

                // plan for "example"
                new ExampleConstruct(settings)
            };

            serviceContainer.RegisterService("request-behaviours", requestBehaviourConstructs.Construct());

            serviceContainer.RegisterServiceNonSingleton("store-user",
                container => new NullUserStore());

            ProcessContext context = new ProcessContext(serviceContainer, FileSystemResourceAdapter.Instance);

            IList<IProcessBehaviour> requestBehaviours =
                context.Services.GetService<IList<IProcessBehaviour>>("request-behaviours");

            context.Register(requestBehaviours);

            context.Params["id"] = "123";

            context.Fire("process-request");

            if(context.IsFlagged("hello"))
            {
                Console.WriteLine("hello");
            }
            else
            {
                Console.WriteLine("sadface");
            }

            if (context.IsFlagged("world"))
            {
                Console.WriteLine("world");
            }
            else
            {
                Console.WriteLine("sadface");
            }

            Console.ReadLine();
        }
    }
}