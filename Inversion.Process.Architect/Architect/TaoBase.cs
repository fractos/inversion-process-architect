using System;
using System.Collections.Generic;
using Inversion.Extensibility.Extensions;

namespace Inversion.Process.Architect
{
    public static class TaoBase
    {
        public static IDictionary<string, IList<string>> BasePraxis
        {
            get
            {
                return new Dictionary<string, IList<string>>
                {
                    {"services", new List<string>()},
                    {"params", new List<string>()},
                    {"control-state", new List<string>()},
                    {"flags", new List<string>()},
                    {"config", new List<string>()},
                    {"emissions", new List<string>()},
                    {"overrides", new List<string>()}
                };
            }
        }

        public static string GetOverride(this IDictionary<string, IList<string>> self, IConfiguration configuration, string name)
        {
            if (!self["overrides"].Contains(name))
            {
                throw new ArgumentException(String.Format("override '{0}' not found", name));
            }

            return configuration.GetOverride(name);
        }

        public static string GetNameWithAssert(this IDictionary<string, IList<string>> self, IConfiguration configuration, string frame, string slot)
        {
            if (!self["config"].Contains(slot))
            {
                throw new ArgumentException(String.Format("config '{0}' not found", slot));
            }

            return configuration.GetNameWithAssert(frame, slot);
        }
    }
}