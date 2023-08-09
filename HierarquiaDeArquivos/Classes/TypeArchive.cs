using System;
using System.Collections.Generic;
using System.Text;

namespace HierarquiaDeArquivos.Classes
{
    public class TypeArchive
    {
        public TypeArchive(string _type, string _value)
        {
            type = _type;
            value = value;
        }

        public string type { get; private set; } = string.Empty;
        public string value { get; private set; } = string.Empty;
    }
}
