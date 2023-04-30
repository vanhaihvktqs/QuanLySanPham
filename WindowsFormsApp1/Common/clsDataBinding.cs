using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsDataBinding
    {
        public string Display { get; set; }
        public object Value { get; set; }
        public clsDataBinding()
        {

        }
        public clsDataBinding(string display, object value)
        {
            Display = display;
            Value = value;
        }
    }
}
