using System.Collections.Generic;
using System.Linq;

using Inversion.Process.Behaviour;
using Inversion.Process.Pipeline;

namespace Inversion.Process.Architect
{
    public class Construct
    {
        public string Message { get; set; }
        public IList<IProcessBehaviour> Behaviours { get; set; }
        public Settings Settings { get; set; }

        public Construct() { }

        protected Construct(string message, Settings settings)
        {
            this.Message = message;
            this.Settings = settings;
        }

        public IDictionary<string, IList<string>> AggregatePraxis
        {
            get {
                IDictionary<string, IList<string>> total = TaoBase.NewPraxis;
                foreach(ITaoBehaviour behaviour in this.Behaviours.Where(b => b is ITaoBehaviour).Cast<ITaoBehaviour>())
                {
                    foreach(KeyValuePair<string, IList<string>> kvp in behaviour.Praxis)
                    {
                        foreach(string value in kvp.Value)
                        {
                            if(!total.ContainsKey(kvp.Key))
                            {
                                total[kvp.Key] = new List<string>();
                            }

                            if(!total[kvp.Key].Contains(value))
                            {
                                total[kvp.Key].Add(value);
                            }
                        }
                    }
                }
                return total;
            }
        }
    }
}