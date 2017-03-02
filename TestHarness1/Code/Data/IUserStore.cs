using System;
using Inversion.Data;

namespace TestHarness1.Code.Data
{
    public interface IUserStore : IStore
    {
        User Get(string id);
    }
}