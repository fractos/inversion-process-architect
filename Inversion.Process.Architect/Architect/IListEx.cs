using System;
using System.Collections.Generic;
using System.Linq;
using Inversion.Process.Behaviour;

namespace Inversion.Process.Architect
{
    public static class IListEx
    {
        public static Func<IServiceContainer, IList<IProcessBehaviour>> Construct(this IList<Construct> constructs)
        {
            IList<IProcessBehaviour> list = constructs.SelectMany(construct => construct.Behaviours).ToList();

            return container => list;
        }
    }
}