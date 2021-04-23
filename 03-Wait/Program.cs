using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Wait
{
    class Program
    {

        static void MethodA()
        {
            Thread.SpinWait(int.MaxValue);
            Console.WriteLine("This is the MethodA");
        }

        static void MethodB()
        {
            Thread.SpinWait(int.MaxValue / 2);
            Console.WriteLine("This is the MethodB");
        }

        static void Main(string[] args)
        {
            Task taskA = Task.Factory.StartNew(MethodA);

            Console.WriteLine("Se inicia la espera de la taskA");
            taskA.Wait();
            Console.WriteLine("Finalizo la espera de la taskA");

            Task taskB = Task.Factory.StartNew(MethodB);

            Console.WriteLine("Se inicia la espera de la taskB");
            taskB.Wait();
            Console.WriteLine("Finalizo la espera de la taskB");

            Console.WriteLine("taskA id = {0}", taskA.Id);
            Console.WriteLine("taskB id = {0}", taskB.Id);

            Console.ReadLine();
        }
    }
}
