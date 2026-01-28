// See https://aka.ms/new-console-template for more information
using _178FunPreDelegates;

Console.WriteLine("Hello, World!");

Publisher pub = new Publisher();
pub.MyEvent += (a, b) => a + b;
Console.WriteLine(pub.RaiseEevent(11,78));
