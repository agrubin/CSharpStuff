using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            //
            // Try inline Lambda.
            //
            //bool foo_equals_bar = Functional.Lambda<string, bool>(str => str.Equals("foo"))("bar");
            //bool btest = Functional.Lambda(() => false)();


            //
            //Intern string speed test.
            //
            //InternString.InternStringTest();

            //
            // Custom format provider.
            //
            Console.WriteLine(String.Format(new FileSizeFormatProvider(), "File size: {0:fs}", 100));
            Console.WriteLine(String.Format(new FileSizeFormatProvider(), "File size: {0:fs}", 10000));

        }


    }
}
