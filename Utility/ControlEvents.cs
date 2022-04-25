using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public class ControlEvents
    {
        private string[] _numericChars = ("1|2|3|4|5|6|7|8|9|0|-|\b|" + CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator).Split('|');
        public void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_numericChars.Contains((e.KeyChar).ToString()))
                e.Handled = true;
        }
    }
}
