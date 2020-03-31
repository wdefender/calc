using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace calc.Common.Services
{
    public class KeyService : IKeyService
    {
        private List<Key> _keys = new List<Key>
        {
            new Key(KeyType.NumericKey, "7"),
            new Key(KeyType.NumericKey, "8"),
            new Key(KeyType.NumericKey, "9"),
            new Key(KeyType.OperatorKey, "/"),
            new Key(KeyType.OperatorKey, "sqrt"),
            new Key(KeyType.NumericKey, "4"),
            new Key(KeyType.NumericKey, "5"),
            new Key(KeyType.NumericKey, "6"),
            new Key(KeyType.OperatorKey, "*"),
            new Key(KeyType.OperatorKey, "%"),
            new Key(KeyType.NumericKey, "1"),
            new Key(KeyType.NumericKey, "2"),
            new Key(KeyType.NumericKey, "3"),
            new Key(KeyType.OperatorKey, "-"),
            new Key(KeyType.OperatorKey, "1/x"),
            new Key(KeyType.NumericKey, "0"),
            new Key(KeyType.OperatorKey, "+/-"),
            new Key(KeyType.NumericKey, ","),
            new Key(KeyType.OperatorKey, "+"),
            new Key(KeyType.OperatorKey, "="),
        };

        public Key GetKeyFromValue(string keyValue)
        {
            return _keys.Where(_ => _.Value == keyValue).FirstOrDefault();
        }

        public IList<Key> GetKeys()
        {            
            return _keys;
        }
    }
}
