using Inversion.Data;

namespace Inversion.Process.Architect.Examples.Data
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