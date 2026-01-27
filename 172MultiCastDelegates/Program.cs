// See https://aka.ms/new-console-template for more information
using _172MultiCastDelegates;

Console.WriteLine("Hello, World!");
Sample sample = new Sample();
MyDelegate mydelegates;
mydelegates = new MyDelegate(sample.Add);
mydelegates += new MyDelegate(sample.Multi);
mydelegates.Invoke(10, 10);
