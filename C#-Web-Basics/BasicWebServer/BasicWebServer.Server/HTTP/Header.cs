using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string _name, string _value)
        {
            Name = _name;
            Value = _value;
        }

        public string Name { get; init; }
        public string Value { get; set; }
    }
}
