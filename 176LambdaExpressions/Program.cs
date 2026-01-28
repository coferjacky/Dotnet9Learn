// See https://aka.ms/new-console-template for more information

using _176LambdaExpressions;

Console.WriteLine("Hello, World!");
Publisher pub = new Publisher();
pub.MyEvent += (a, b) => //pub.MyEvent += (a, b) => //为什么这里参数不写数据类型，因为委托已经给你写好了
{
   
    return a + b;
};

Console.WriteLine(pub.RaiseEvent(12, 13)); 