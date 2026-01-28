using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _174AutoImplementedEvents
{


    internal class SubScriber
    {//订阅者类
        public void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }


        public void Multi(int x, int y)
        {
            Console.WriteLine(x * y);
        }
    }


}
