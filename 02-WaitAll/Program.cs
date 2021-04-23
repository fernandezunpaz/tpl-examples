using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_WaitAll
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
            Thread.SpinWait(int.MaxValue/2);
            Console.WriteLine("This is the MethodB");
        }

        static void Main(string[] args)
        {
            Task taskA = Task.Factory.StartNew(MethodA);
            Task taskB = Task.Factory.StartNew(MethodB);

            Console.WriteLine("taskA id = {0}", taskA.Id);
            Console.WriteLine("taskB id = {0}", taskB.Id);

            var tasks = new Task[] { taskA, taskB };
            Task.WaitAll(tasks);

        }
    }
}
