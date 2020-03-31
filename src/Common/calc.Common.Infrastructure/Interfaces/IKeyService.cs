using calc.Common.Infrastructure.Models;
using System.Collections.Generic;

namespace calc.Common.Infrastructure.Interfaces
{
    public interface IKeyService
    {
        IList<Key> GetKeys();
        Key GetKeyFromValue(string keyValue);
    }
}
