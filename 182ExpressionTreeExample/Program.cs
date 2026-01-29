// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");

Expression<Func<int,int>> e=x=>x*x;
Func<int,int> mydelegates=e.Compile();



Console.WriteLine(mydelegates.Invoke(10)); 