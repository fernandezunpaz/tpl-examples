using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_WaitAny
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
            Task taskB = Task.Factory.StartNew(MethodB);

            Console.WriteLine("Se inicia la espera de taskA o taskB");

            var tasks = new Task[] { taskA, taskB };
            int whichTask = Task.WaitAny(tasks);

            Console.WriteLine("Finalizo la espera de la tarea {0}", tasks[whichTask].Id);

            Console.WriteLine("taskA id = {0}", taskA.Id);
            Console.WriteLine("taskB id = {0}", taskB.Id);

            //Console.ReadLine();
        }
    }
}
