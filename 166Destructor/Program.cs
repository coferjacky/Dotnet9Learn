// See https://aka.ms/new-console-template for more information
using _166Destructor;

//Console.WriteLine("Hello, World!");
Sample sample = new Sample();
sample.DisplayDate();
sample = null; // 将对象置为不可达\
GC.Collect();
GC.WaitForPendingFinalizers();
Console.WriteLine("等待析构函数执行...");
Thread.Sleep(1000); // 添加延迟，观察析构函数是否被调用
//Console.ReadKey();
