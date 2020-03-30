using calc.Common.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace calc.Common.Infrastructure.Models
{
    public class Key
    {
        public KeyType Type { get; }
        public string Value { get; }

        public Key(KeyType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
