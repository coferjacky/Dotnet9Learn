using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _166Destructor
{
    public class Sample
    {
        public Sample() {
            Console.WriteLine("db conn");
        }
        ~Sample()
        {
            Console.WriteLine("析构函数被调用");
        }
        public void DisplayDate()
        {
            Console.WriteLine("db date display");
        }


        

    }
}
