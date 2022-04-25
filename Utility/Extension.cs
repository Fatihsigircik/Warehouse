using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Extension
    {
        public static T Cast<T>(this object o)
        {
            return General.Cast<T>(o);
        }

    }
}
