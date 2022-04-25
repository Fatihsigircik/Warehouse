using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
   public  class General
    {
        public static readonly char[] NumericChars = new[]
        {
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', (char) Keys.Back, (char) Keys.Delete, Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0],
            (char) Keys.Right, (char) Keys.Left
        };

        public static T Cast<T>(object o)
        {
            return (T) o;
        }
    }
}
