using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sample2___Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            var TaskA = Task.Factory.StartNew(MethodA);
            var TaskB = Task.Factory.StartNew(MethodB);
            Task TaskC = null;

            try
            {


                TaskC = Task.Factory.StartNew(() =>
                {
                    int a = 5;
                    int b = 0;

                    a /= b;
                });

                Task.WaitAll(new Task[] { TaskA, TaskB, TaskC });
            }
            catch (AggregateException exp)
            {
                Console.WriteLine("Exception happend: " +TaskA.Status.ToString());
                foreach (var ex in exp.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Completed");

            Console.ReadLine();
        }

        static void MethodA()
        {
            throw new Exception("TaskA Exception");
        }

        static void MethodB()
        {
            throw new Exception("TaskB Exception");
        }
    }
}
