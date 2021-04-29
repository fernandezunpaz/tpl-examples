using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_ContinueWith
{
    class Program
    {
        static void Main(string[] args)
        {

            int stock = 100;

            Task<int> t1 = new Task<int>( (arg) => {
                //Consulto base de datos de inventario del almacen B
                Thread.Sleep(4000);
                int stockLocal = (int)arg;
                stockLocal += 5;
                return stockLocal;
            }, stock);

            t1.Start();

            Task<int> t2 = t1.ContinueWith( (predecesor) => {
                //Consulto base de datos de inventario del almacen X
                int stockLocal = predecesor.Result;
                stockLocal += 10;
                return stockLocal;
            });
            
            t2.Wait();

            Console.WriteLine("El stock es {0}", t2.Result);
        }
    }
}
