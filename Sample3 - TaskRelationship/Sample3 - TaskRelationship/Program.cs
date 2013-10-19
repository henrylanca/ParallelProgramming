using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sample3___TaskRelationship
{
    class Program
    {
        static void Main(string[] args)
        {
            var antecedent = new Task<int>(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("antecedent");
                return 100;
            });

            var successor = antecedent.ContinueWith((firstTask)=>{
                Console.WriteLine("Successor");
                Console.WriteLine(string.Format("Result={0}", antecedent.Result));
            });

            antecedent.Start();

            Task.WaitAll(antecedent, successor);

            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
