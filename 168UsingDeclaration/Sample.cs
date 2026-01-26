using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _168UsingDeclaration
{
    public class Sample : IDisposable
    {
        public Sample() {
            Console.WriteLine("db conn");
        }
        
        public void DisplayDate()
        {
            Console.WriteLine("db date display");
        }

        public void Dispose()
        {
            Console.WriteLine("析构函数被调用");
        }
    }
}
