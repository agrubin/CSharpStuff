using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public static class ExtensionMethods
    {
        public static string ToFileSize(this long l)
        {
            return String.Format(new FileSizeFormatProvider(), "{0:fs}", l);
        }
    }
}
