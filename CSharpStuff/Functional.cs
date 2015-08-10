using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
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
}
