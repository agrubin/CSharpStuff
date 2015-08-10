using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class InternString    {
        public static void InternStringTest()
    {
        // 1.
        // Create string at runtime.
        StringBuilder b = new StringBuilder().Append("cat ").Append(
            "and ").Append("dog");
        // 2.
        // Get runtime string.
        string s1 = b.ToString();
        // 3.
        // Get string pool reference to string.
        string s2 = string.Intern(s1);

        // 4.
        // Three loops:
        // - Repeat benchmark 10 times
        // - Repeat inner loop 10000 times
        // - Repeat 2 tests 10000 times
        int m = 10000;
        for (int v = 0; v < 10; v++)
        {
            int d = 0;
            long t1 = Environment.TickCount;

            // 5.
            // Test regular string.
            for (int i = 0; i < m; i++)
            {
                for (int a = 0; a < m; a++)
                {
                    if (s1 == "cat and rabbit")
                    {
                        d++; // false
                    }
                    if (s1 == "cat and dog")
                    {
                        d--; // true
                    }
                }
            }
            long t2 = Environment.TickCount;

            // 6.
            // Test interned string.
            for (int i = 0; i < m; i++)
            {
                for (int a = 0; a < m; a++)
                {
                    if (s2 == "cat and rabbit")
                    {
                        d++; // false
                    }
                    if (s2 == "cat and dog")
                    {
                        d--; // true
                    }
                }
            }
            // 7.
            // Write results.
            long t3 = Environment.TickCount;
            Console.Write((t2 - t1));
            Console.WriteLine("," + (t3 - t2));
        }
        Console.ReadLine();
    }        
    }
 
}
