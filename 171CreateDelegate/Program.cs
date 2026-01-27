// See https://aka.ms/new-console-template for more information
using _171CreateDelegate;

Console.WriteLine("Hello, World!");

DelegateAdd Delegateadd;
Sample sample = new Sample();
Delegateadd = new DelegateAdd(sample.Add);
Console.WriteLine(Delegateadd.Invoke(5, 6));