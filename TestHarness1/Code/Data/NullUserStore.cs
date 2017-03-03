using System;
using Inversion.Data;

namespace TestHarness1.Code.Data
{
    public class NullUserStore : StoreBase, IUserStore
    {
        public override void Dispose()
        {
            // nothing to do
        }

        public User Get(string id)
        {
            return new User(id);
        }
    }
}