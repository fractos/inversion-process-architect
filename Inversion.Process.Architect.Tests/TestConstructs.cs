using System;
using System.Collections.Generic;
using System.Linq;
using Inversion.Data;
using Inversion.Process.Architect.Tests.Constructs;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inversion.Process.Architect.Tests
{
    [TestClass]
    public class TestConstructs : IDisposable
    {
        protected IServiceContainer serviceContainer;
        protected IServiceContainerQuery query;
        protected IServiceContainerRegistrar registrar;

        [TestInitialize]
        public void Initialise()
        {
            serviceContainer = new Inversion.Naiad.ServiceContainer();
            query = (IServiceContainerQuery) serviceContainer;
            registrar = (IServiceContainerRegistrar) serviceContainer;
        }

        [TestMethod]
        public void ConstructAddsParameterisedSequenceBehaviour()
        {
            Settings settings = new Settings(ConfigurationHelper.GetConfigurationFromConfig());

            IList<Construct> requestBehaviourConstructs = new List<Construct>
            {
                // plan for "process-request"
                new ParameterisedSequenceBehaviourConstruct(settings),
            };

            registrar.RegisterService("request-behaviours", requestBehaviourConstructs.Construct());

            Assert.IsTrue(query.ContainsService("request-behaviours"));

            IList<IProcessBehaviour> behaviours = serviceContainer.GetService<IList<IProcessBehaviour>>("request-behaviours");
            Assert.IsTrue(behaviours != null);

            IProcessBehaviour behaviour = behaviours.SingleOrDefault(b => b.RespondsTo == "message");

            Assert.IsTrue(behaviour != null);
            Assert.IsTrue(behaviour.GetType() == typeof(ParameterisedSequenceBehaviour));
        }

        [TestMethod]
        public void ConstructedContextContainsSetFlag()
        {
            Settings settings = new Settings(new Dictionary<string, string>
            {
                {"world", "world" }
            });

            IList<Construct> requestBehaviourConstructs = new List<Construct>
            {
                // plan for "process-request"
                new ProcessRequestConstruct(settings),
                new BootstrapConstruct(settings)
            };

            registrar.RegisterService("request-behaviours", requestBehaviourConstructs.Construct());

            ProcessContext context = new ProcessContext(serviceContainer, FileSystemResourceAdapter.Instance);

            IList<IProcessBehaviour> requestBehaviours =
                context.Services.GetService<IList<IProcessBehaviour>>("request-behaviours");

            context.Register(requestBehaviours);

            context.Fire("process-request");

            Assert.IsTrue(context.IsFlagged("hello"));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            this.serviceContainer.Dispose();
        }
    }
}