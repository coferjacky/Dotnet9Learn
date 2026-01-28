// See https://aka.ms/new-console-template for more information
using _175AnonymousExample;

Console.WriteLine("Hello, World!");


//创建发布者对象
Publisher pub = new Publisher();


//订阅  此处你不用单独写void，因为委托已经帮你写好了,但是匿名方法前面要加delegate
pub.MyEvent += delegate(int a , int b){ Console.WriteLine(a+b); };
pub.MyEvent += delegate (int c, int d) { Console.WriteLine(c * d); };
//触发事件,使得两个方法执行
pub.RaiseEvent(10, 20);