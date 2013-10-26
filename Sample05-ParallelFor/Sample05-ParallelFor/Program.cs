using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Sample05_ParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < 100000000; i++)
            {
                DoSomething(i);
            }
            watch.Stop();

            TimeSpan ts = watch.Elapsed;
            Console.WriteLine(string.Format("Time Passed: {0}", ts.Milliseconds));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, 100000000, (i) =>
            {
                DoSomething(i);
            });
            stopwatch.Stop();

            ts = stopwatch.Elapsed;

            Console.WriteLine(string.Format("Time Passed: {0}", ts.Milliseconds));
            Console.ReadLine();
        }

        static void DoSomething(int i)
        {
            double d = Math.Sqrt(i);

            //if(i%1000000==0)
            //    Console.WriteLine(string.Format("{0} : {1}", i,d));
        }
    }
}
