using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ReturningResults
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<int> t1 = new Task<int>(() =>
            {
                return 42;
            });

            t1.Start();

            t1.Wait();
            int result = t1.Result;
            Console.WriteLine("El resultado de t1 es: {0}", result.ToString());

        }
    }
}
