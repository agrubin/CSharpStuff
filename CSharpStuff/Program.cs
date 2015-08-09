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
        public static void InternString()
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

                long t3 = Environment.TickCount;

                // 7.
                // Test interned string in a parallel loop (this doesn't save any time...try it with collections later).
                for (int i = 0; i < m; i++)
                {
                    Parallel.For(0, m, a =>
                    {
                        if (s2 == "cat and rabbit")
                        {
                            d++; // false
                        }
                        if (s2 == "cat and dog")
                        {
                            d--; // true
                        }
                    });
                }

                // 8.
                // Write results.
                long t4 = Environment.TickCount;

                Console.Write((t2 - t1));
                Console.WriteLine("," + (t3 - t2));
                Console.WriteLine("," + (t4 - t3));
            }
            Console.WriteLine("\nDone!");
            Console.ReadLine();
        }

        //
        // This is a simple way of implementing a sort of "inline lambda expression".
        //
        public static class Functional
        {
            public static Func<TResult> Lambda<TResult>(Func<TResult> func)
            {
                return func;
            }

            public static Func<T, TResult> Lambda<T, TResult>(Func<T, TResult> func)
            {
                return func;
            }

            public static Func<T1, T2, TResult> Lambda<T1, T2, TResult>(Func<T1, T2, TResult> func)
            {
                return func;
            }
        }
        static void Main(string[] args)
        {
            //
            // Try inline Lambda.
            //

            bool foo_equals_bar = Functional.Lambda<string, bool>(str => str.Equals("foo"))("bar");
            bool btest = Functional.Lambda(() => false)();

            InternString();
            
        }
    }
}
