using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class Param
    {
        public string Value { get; set; }
        public Param(string p)
        {
            Value = "'"+p+"'";
        }
        public Param(int p)
        {
            Value = p.ToString();
        }
    }
}
