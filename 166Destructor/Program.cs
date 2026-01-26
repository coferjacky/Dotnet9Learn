// See https://aka.ms/new-console-template for more information
using System.Threading;
using _166Destructor;

Console.WriteLine("方法1: 使用WeakReference确保对象被GC回收");
WeakReference<Sample> weakRef = CreateSample();
GC.Collect();
GC.WaitForPendingFinalizers();


Console.WriteLine("程序结束");

WeakReference<Sample> CreateSample()
{
    var sample = new Sample();
    sample.DisplayDate();
    return new WeakReference<Sample>(sample);
}
