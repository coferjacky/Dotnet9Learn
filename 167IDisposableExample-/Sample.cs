using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _167IDisposableExample
{
    internal class Sample:IDisposable
    {
        public Sample() {
            Console.WriteLine("db connet");
        }

        public void DisplayDate()
        {
            Console.WriteLine("db date display");
        }

        public void Dispose()
        {
            Console.WriteLine("connect close");
        }       

    }
}
