using Inversion.Data;

namespace Inversion.Process.Architect.Examples.Data
{
    public interface IUserStore : IStore
    {
        User Get(string id);
    }
}