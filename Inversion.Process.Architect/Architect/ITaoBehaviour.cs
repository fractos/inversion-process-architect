using System.Collections.Generic;
using Inversion.Process.Behaviour;

namespace Inversion.Process.Architect
{
    public interface ITaoBehaviour : IProcessBehaviour
    {
        IDictionary<string, IList<string>> Praxis
        {
            get;
        }
    }
}