using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sample001
{
    class Program
    {
        static void Main(string[] args)
        {
            var TaskA = Task.Factory.StartNew(MethodA);
            var TaskB = Task.Factory.StartNew(MethodB);

            var TaskC = Task<int>.Factory.StartNew(val =>
            {
                return ((string)val).Length;
            },
                "On Thursday, the Cow jumped");

            Task.WaitAll(new Task[] { TaskA, TaskB, TaskC });

            Console.WriteLine(string.Format("{0}", TaskC.Result));

            Console.ReadLine();
        }

        static void MethodA()
        {
            Console.WriteLine("MethodA");
        }

        static void MethodB()
        {
            Console.WriteLine("MethodB");
        }
    }
}
