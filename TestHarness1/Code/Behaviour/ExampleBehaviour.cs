using System;
using System.Collections.Generic;
using Inversion.Extensibility.Extensions;
using Inversion.Process;
using Inversion.Process.Architect;
using Inversion.Process.Behaviour;
using TestHarness1.Code.Data;

namespace TestHarness1.Code.Behaviour
{
    public class ExampleBehaviour : TaoBehaviour
    {
        public ExampleBehaviour(string respondsTo) : base(respondsTo) {}
        public ExampleBehaviour(string respondsTo, IPrototype prototype) : base(respondsTo, prototype) {}
        public ExampleBehaviour(string respondsTo, IEnumerable<IConfigurationElement> config) : base(respondsTo, config) {}

        public override void Action(IEvent ev, IProcessContext context)
        {
            string storeUser = this.Configuration.GetOverride("store-user");

            string outputKey = this.Configuration.GetNameWithAssert("config", "output-key");
            string loadedUserMessageName = this.Configuration.GetNameWithAssert("config", "emit-this-message");

            // I can see how it would be easier to declare the assertion on the "id" parameter
            // compared to allowing the parameter name to be set by a configuration value.
            // - could configuration elements for this purpose be annointed somehow?
            // - maybe use overrides ?

            string id = context.Params.GetWithAssert("id");

            User user = null;

            using (IUserStore userStore = context.Services.GetService<IUserStore>(storeUser))
            {
                userStore.Start();

                user = userStore.Get(id);
            }

            context.ControlState[outputKey] = user;

            context.Fire(loadedUserMessageName);
        }
    }
}