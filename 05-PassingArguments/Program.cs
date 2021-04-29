using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_PassingArguments
{
    class Program
    {

        static void Main(string[] args)
        {
            int spinWaitValueForT1 = int.MaxValue;
            int spinWaitValueForT2 = 100000;

            Task t1 = Task.Factory.StartNew( (spinWaitValue) => {
                Thread.SpinWait((int)spinWaitValueForT1);
                Console.WriteLine("This is the MethodA. I wait " + (int)spinWaitValueForT1);
            }, spinWaitValueForT1);

            Task t2 = Task.Factory.StartNew((spinWaitValue) => {
                Thread.SpinWait((int)spinWaitValue);
                Console.WriteLine("This is the MethodB. I wait " + (int)spinWaitValue);
            }, spinWaitValueForT2);

            Task.WaitAll(new Task[] { t1, t2 });
            Console.ReadLine();
        }
    }
}
