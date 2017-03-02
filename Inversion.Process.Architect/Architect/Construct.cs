using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace Inversion.Process.Architect
{
    public abstract class Construct
    {
        public string Message { get; set; }
        public IList<IProcessBehaviour> Behaviours { get; set; }
        public Settings Settings { get; set; }

        protected Construct(string message, Settings settings)
        {
            this.Message = message;
            this.Settings = settings;
        }
    }
}