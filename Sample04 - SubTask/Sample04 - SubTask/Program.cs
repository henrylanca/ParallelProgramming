using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sample04___SubTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task Outer = new Task(() =>
            {
                Console.WriteLine("Outer Task");

                var inner = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task");
                }, TaskCreationOptions.AttachedToParent);

                //inner.Wait();

            });

            Outer.Start();
            Outer.Wait();

            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
