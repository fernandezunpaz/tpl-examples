using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_TwoTasks
{
    class Program
    {
        static void MethodA()
        {
            Thread.Sleep(3000);
            Console.WriteLine("This is the MethodA");
        }

        static void MethodB()
        {
            Thread.Sleep(3000);
            Console.WriteLine("This is the MethodB");
        }

        static void Main(string[] args)
        {
            Task taskA = Task.Factory.StartNew(MethodA);
            Task taskB = Task.Factory.StartNew(MethodB);

            //Another Task execution
            //Task taskA = new Task(MethodA);
            //taskA.Start();
            //Task taskB = new Task(MethodB);
            //taskB.Start();

            //Another Task execution
            //Parallel.Invoke(new Action[] { MethodA, MethodB } );
            
            //...
            //...
            //...

            Console.ReadKey();
        }
    }
}
