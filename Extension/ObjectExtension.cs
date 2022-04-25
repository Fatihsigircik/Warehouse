using System;

namespace Extension
{
    public static class ObjectExtension
    {
        public static int ToInt(this object o)
        {
            try
            {
                return int.TryParse(o.ToString(), out var i) ? i : Convert.ToInt32(o);
            }
            catch
            {
                return 0;
            }
        }
    }
}
