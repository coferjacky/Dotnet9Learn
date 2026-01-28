// See https://aka.ms/new-console-template for more information
using _177InnerLambdaExpressions;

Console.WriteLine("Hello, World!");

Publisher pub = new Publisher();

pub.MyEvent += (a, b) => a + b;

Console.WriteLine(pub.RaiseEvent(10, 4)); 