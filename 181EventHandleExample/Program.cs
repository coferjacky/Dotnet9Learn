using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _181EventHandleExample
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            Program p = new Program();
            p.DoWork();
        }
        public void DoWork()
        {
            Publisher pub = new Publisher();

            pub.myEvent += (sender, q) =>
            {
                int c = q.a + q.b;
                Console.WriteLine("result:" + c);
            };
            pub.RaiseEvent(this, 10, 50);
        }
    }




    //主方法内部，无法访问this关键字   所以这段代码  Console.WriteLine(pub.RaiseEvent(this,12,13)) 要单独封装到主方法外的方法中;


}

